﻿using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class BillBuy_Repo : IApplicationRepository<BillBuy>
    {
        Application_Identity_DbContext DbContext;
        public BillBuy_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(BillBuy entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BillBuy entity)
        {
            throw new NotImplementedException();
        }

        public BillBuy GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<BillBuy> Get_All_BillBuy_List()
        {
            throw new NotImplementedException();

        }

        public IList<BillBuy> List()
        {
            throw new NotImplementedException();
        }

        //internal double GetBillBuyValue(int billid)
        //{
        //    throw new NotImplementedException();

        //}
        //internal double GetBillBuy_PaysValue(int billid)
        //{
        //    throw new NotImplementedException();
        //}
        //internal List<PayIN> Get_Billbuy__Returns_Pays(int billbuyid)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
