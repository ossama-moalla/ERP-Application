using ERP_System.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Customer_Repository
{
    public class Customer_Repo:IApplicationRepository<Customer>
    {
        Application_Identity_DbContext DbContext;
        public Customer_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<Customer> GetCustomerList()
        {
            throw new NotImplementedException();

        }
    }
}
