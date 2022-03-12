using ERP_System.Models;
using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using ERP_System.Models.Trade.Reports.SalesBillsReport;
using ERP_System.Repositories.Accounting_Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class SalesBill_Repo : IApplicationRepository<SalesBill>,
        IReportByDateTypeRepository<SalesBill, SalesBillsReport_DayReport,SalesBillsReport_MonthReport, 
            SalesBillsReport_YearReport, SalesBillsReport_YearRangeReport>
    {
        private readonly Application_Identity_DbContext DbContext;
        private readonly IApplicationRepository<PayIN> PayIN_Repo;
        private readonly IApplicationRepository<ItemOUT> ItemOUT_Repo;
        public SalesBill_Repo(Application_Identity_DbContext DbContext_, IApplicationRepository<PayIN> PayIN_Repo, IApplicationRepository<ItemOUT> ItemOUT_Repo)
        {
            DbContext = DbContext_;
            this.PayIN_Repo = PayIN_Repo;
            this.ItemOUT_Repo = ItemOUT_Repo;
        }

        public SalesBill Add(SalesBill entity)
        {
            DbContext.Trade_SalesBill.Add(entity);
            DbContext.SaveChanges();
            return entity;
            
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if (entity != null) LocalException.ThrowNotFound("Delete Failed! Sales Bill with Id:" + id + " Not Exists");
            DbContext.Trade_SalesBill.Remove(entity);
            DbContext.SaveChanges();
            
        }

        public void Update(SalesBill entity)
        {
            var SalesBill = DbContext.Trade_SalesBill.SingleOrDefault(x => x.Id == entity.Id);
            if (SalesBill == null) LocalException.ThrowNotFound("Update Failed! Sales Bill with Id:" + entity.Id + " Not Exists");
            SalesBill.Date = entity.Date;
            SalesBill.Description = entity.Description;
            SalesBill.DealerId = entity.DealerId;
            SalesBill.SellTypeId = entity.SellTypeId;
            SalesBill.CurrencyId = entity.CurrencyId;
            SalesBill.ExchangeRate = entity.ExchangeRate;
            SalesBill.Discount = entity.Discount;
            SalesBill.Notes = entity.Notes;
            DbContext.SaveChanges();
            
        }

        public SalesBill GetByID(int id)
        {
            var SalesBill = DbContext.Trade_SalesBill.Include(x => x.Currency)
                .Include(x => x.Dealer).Include(x => x.SellType).SingleOrDefault(x => x.Id == id);
            DbContext.Entry(SalesBill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            if (SalesBill == null) return null;
            if (SalesBill.Currency == null) SalesBill.Currency = Currency.ReferenceCurrency;
            SalesBill.ItemsOUT = ItemOUT_Repo.List().Where(x => x.OperationType == Operation.SALES_BILL && x.OperationId == SalesBill.Id).ToList();
            SalesBill.PaysIN = PayIN_Repo.List().Where(x => x.OperationType == Operation.SALES_BILL && x.OperationId == SalesBill.Id).ToList();
            SalesBill.BillValue = SalesBill.ItemsOUT.Sum(x => x.Amount * x.SingleOUTValue_MoneyValue_Currency.MoneyValue);
            return SalesBill;
        }

        public IList<SalesBill> List()
        {
            var list = DbContext.Trade_SalesBill.Include(x=>x.Currency)
                .Include(x => x.Dealer).Include(x => x.SellType).ToList();
            foreach (var SalesBill in list)
            {
                DbContext.Entry(SalesBill).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                if (SalesBill.Currency == null) SalesBill.Currency = Currency.ReferenceCurrency;
                SalesBill.ItemsOUT = ItemOUT_Repo.List().Where(x => x.OperationType == Operation.SALES_BILL && x.OperationId == SalesBill.Id).ToList();
                SalesBill.PaysIN = PayIN_Repo.List().Where(x => x.OperationType == Operation.SALES_BILL && x.OperationId == SalesBill.Id).ToList();
                SalesBill.BillValue = SalesBill.ItemsOUT.Sum(x => x.Amount * x.SingleOUTValue_MoneyValue_Currency.MoneyValue);
            }
            return list;
        }

        public SalesBillsReport_DayReport DayReport(List<SalesBill> Operations, int year, int month, int day)
        {
            List<SalesBill_Report> SalesBill_Report_List = new();
            var list = Operations.Where(x => x.Date.Day == day && x.Date.Month == month && x.Date.Year == year);
            foreach (var salesbill in list)
            {
                SalesBill_Report_List.Add(salesbill.Convert_To_SalesBill_Report());
            }
            return new SalesBillsReport_DayReport()
            {
                Year = year,
                Month = month,
                Day = day,
                SalesBillReport_List = SalesBill_Report_List
            };


        }

        public SalesBillsReport_MonthReport MonthReport(List<SalesBill> Operations, int year, int month)
        {
            var SalesBillsReport_InDay_List = new List<SalesBillsReport_InDay>();
            var salesbill_inmonth = Operations.Where(x => x.Date.Month == month && x.Date.Year == year);
            int max_days = DateTime.DaysInMonth(year, month);
            for (int i = 1; i <= max_days; i++)
            {
                var salesbill_inday = salesbill_inmonth.Where(x => x.Date.Day == i).ToList();
                var itemsin_Moneyvalue_currency = new List<MoneyValue_Currency>();
                var paysin = new List<PayIN>() ;
                var billsvalue_paysin_remain = new List<MoneyValue_Currency>();

                foreach (var salesbill in salesbill_inday)
                {
                    paysin.AddRange(salesbill.PaysIN);
                    foreach(var itemout in salesbill.ItemsOUT)
                    {
                        var moneyvalue_currency = itemout.ItemIN.SingleCost_MoneyValue_Currency;
                        moneyvalue_currency.MoneyValue *= itemout.Amount;
                        itemsin_Moneyvalue_currency.Add(moneyvalue_currency);
                    }
                    var PaysValueAccordingToBillCurrency = salesbill.get_PaysValueAccordingToBillCurrency();
                    if (PaysValueAccordingToBillCurrency != 0)
                        billsvalue_paysin_remain.Add(
                            new MoneyValue_Currency()
                            {
                                MoneyValue = salesbill.BillValue - PaysValueAccordingToBillCurrency
                                ,
                                Currency = salesbill.Currency,
                                ExchangeRate = salesbill.ExchangeRate
                            });
                }

                var salesbills_reportinday = new SalesBillsReport_InDay()
                {
                    DayNO=i,
                    DayDate=new DateTime(year,month,i),
                    Bills_Count= salesbill_inday.Count,
                    Bills_Value=MoneyValue_Currency.Combine_MoneyValue_Currency(salesbill_inday.SelectMany(x=>x.PaysIN.Select(y=>y.MoneyValue_Currency).ToList()).ToList()),
                    Bills_Pays_Value= MoneyValue_Currency.Combine_MoneyValue_Currency(paysin.Select(x=>x.MoneyValue_Currency).ToList()),
                    Bills_Value_Remain=MoneyValue_Currency.Combine_MoneyValue_Currency( billsvalue_paysin_remain),
                    Bills_RealValue=Math.Round( salesbill_inday.Sum(x=>x.BillValue /x.ExchangeRate),2),
                    Bills_Pays_RealValue=Math.Round( paysin.Sum(x=>x.Value /x.ExchangeRate),2),
                    Bills_ItemsIN_Value=MoneyValue_Currency.Combine_MoneyValue_Currency(itemsin_Moneyvalue_currency),
                    Bills_ItemsIN_RealValue=Math.Round( itemsin_Moneyvalue_currency.Sum(x=>x.MoneyValue*x.ExchangeRate),2)
                };
                SalesBillsReport_InDay_List.Add(salesbills_reportinday);

            }
            return new SalesBillsReport_MonthReport()
            {
                Year = year,
                Month = month,
                SalesBillsReport_InDay_List = SalesBillsReport_InDay_List
            };
        }

        public SalesBillsReport_YearReport YearReport(List<SalesBill> Operations, int year)
        {
            throw new NotImplementedException();
        }

        public SalesBillsReport_YearRangeReport YearRangeReport(List<SalesBill> Operations, int year1, int year2)
        {
            throw new NotImplementedException();
        }
    }
}
