using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class Premession
    {
        public enum Premession_Group_Type
        {
             ADMIN_GROUP = 0,
             BUY_GROUP = 1,
             SELL_GROUP = 2,
             MAINTENANCE_GROUP = 3,
             EMPLOYEE_GROUP = 4,
             ITEM_GROUP = 5,
             CONTACT_GROUP = 6,
             INDUSTRY_GROUP = 7,
             CONTAINER_GROUP = 8,
        }
        public uint GroupID;
        public bool Join;
        public Premession(uint GroupID_, bool Join_)
        {
            GroupID = GroupID_;
            Join = Join_;
        }


    }
}
