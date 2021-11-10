using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers
{
    public class Customer
    {
        public const bool CUSTOMER_PERSON = false;
        public const bool CUSTOMER_COMPANY = true;

        public uint CustomerID;
        public bool CustomerType;
        public string CustomerName;
        public string Phone;
        public string Mobile;
        public string Address;
        public Customer(uint CustomerID_, bool CustomerType_, string CustomerName_, string Phone_, string Mobile_, string Address_)
        {
            CustomerID = CustomerID_;
            CustomerType = CustomerType_;
            CustomerName = CustomerName_;
            Phone = Phone_;
            Mobile = Mobile_;
            Address = Address_;
        }
        public string GetCustomerTypeString()
        {
            if (CustomerType == Customer.CUSTOMER_COMPANY) return "شركة";
            else return "شخص";
        }
        public string GetCustomerTypeHeader()
        {
            if (CustomerType == Customer.CUSTOMER_COMPANY) return "شركة";
            else return "السيد";
        }
        public static string ConvertTypeToString(bool type)
        {
            if (type == Customer.CUSTOMER_COMPANY) return "شركة";
            else return "شخص";
        }
        public string Get_Complete_CustomerName_WithHeader()
        {
            return GetCustomerTypeHeader() + ":" + CustomerName;
        }
    }
}
