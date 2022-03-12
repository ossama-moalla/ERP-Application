
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System
{
    public class LocalException:Exception
    {
        public int StatusCode { get; set; }
        public LocalException(int StatusCode,string message):base(message)
        {
            this.StatusCode = StatusCode;
        }

        public static void ThrowNotFound(string message)
        {
            throw new LocalException(StatusCodes.Status404NotFound, message);
        }
        public static ObjectResult HanldeException(Exception e)
        {
            if (e.GetType() == typeof(LocalException))
            {
                LocalException local = (LocalException)e;
                var objectresult=new ObjectResult(new ErrorResponse() { Message = local.Message });
                objectresult.StatusCode = local.StatusCode;
                return objectresult;
            }
            else
            {
                var objectresult = new ObjectResult("Internal Server Error");
                objectresult.StatusCode = StatusCodes.Status500InternalServerError;
                return objectresult;
            }
        }
    }
}
