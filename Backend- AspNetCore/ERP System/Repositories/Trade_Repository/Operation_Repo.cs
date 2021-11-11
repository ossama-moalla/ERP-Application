using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class Operation_Repo
    {
        public Currency GetOperationItemINCurrency(Operation operation)
        {
            throw new NotImplementedException();
        }
        public Currency GetOperation_BillAdditionalClause_Currency(Operation operation)
        {
            throw new NotImplementedException();
        }
        public Currency GetOperationItemOUTCurrency(Operation operation)
        {
            throw new NotImplementedException();
        }
        public IBill GetOperationBill(Operation operation)
        {
            throw new NotImplementedException();
        }
        public double Get_OperationValue(uint OperationType, uint OperationID)
        { 
            throw new NotImplementedException();
        }
        public double Get_OperationPaysValue_UPON_OperationCurrency(uint OperationType, uint OperationID)
        {
            throw new NotImplementedException();
        }
        public double Get_OperationValue(Operation Operation_)
        {
            throw new NotImplementedException();

        }
        public double Get_OperationPaysValue_UPON_OperationCurrency(Operation Operation_)
        {
            throw new NotImplementedException();
        }
        internal List<Operation> GetItemOUT_Real_OUTOperations(ItemOUT ItemOUT_)
        {
            throw new NotImplementedException();
        }
        
    }
}
