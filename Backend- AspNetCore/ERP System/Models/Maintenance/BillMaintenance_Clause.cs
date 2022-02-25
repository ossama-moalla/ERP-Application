using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class BillMaintenance_Clause
    {
        public enum BillMaintenance_Clause_Types:ushort
        {
            ITEMOUT_TYPE = 1,
            REPAIR_OPR_TYPE = 2,
            DIAGNOSTIC_OPR_TYPE = 3,
            AdditionalClause_TYPE = 4,
        }
        public readonly ushort ClauseType;
        public int BillID { get; }
        public RepairOPR _RepairOPR { get; }
        public ItemOUT _ItemOUT { get; }
        public BillAdditionalClause _BillAdditionalClause { get; }
        public DiagnosticOPR _DiagnosticOPR { get; }
        public double? Value { get; }
        public BillMaintenance_Clause(int BillID_, ItemOUT ItemOUT_)
        {
            ClauseType = (ushort)BillMaintenance_Clause_Types. ITEMOUT_TYPE;
            BillID = BillID_;
            _ItemOUT = ItemOUT_;
            Value = _ItemOUT.SingleOUTValue;
        }
        public BillMaintenance_Clause(int BillID_, BillAdditionalClause BillAdditionalClause_)
        {
            ClauseType = (ushort)BillMaintenance_Clause_Types.AdditionalClause_TYPE;
            BillID = BillID_;
            _BillAdditionalClause = BillAdditionalClause_;
            Value = _BillAdditionalClause.Value;
        }
        public BillMaintenance_Clause(int BillID_, RepairOPR RepairOPR_, double? Value_)
        {
            ClauseType = (ushort)BillMaintenance_Clause_Types.REPAIR_OPR_TYPE;
            BillID = BillID_;
            _RepairOPR = RepairOPR_;
            Value = Value_;
        }
        public BillMaintenance_Clause(int BillID_, DiagnosticOPR DiagnosticOPR_, double? Value_)
        {
            ClauseType = (ushort)BillMaintenance_Clause_Types.DIAGNOSTIC_OPR_TYPE;
            BillID = BillID_;
            _DiagnosticOPR = DiagnosticOPR_;
            Value = Value_;
        }
    }
}
