using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System
{
    public class MyException:Exception
    {
        public MyException(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }

        public string ErrorMessage { get; }
    }
}
