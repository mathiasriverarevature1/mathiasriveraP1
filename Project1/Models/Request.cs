using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Request
    {
        public Request(Guid requestID, Guid fK_EmployeeID, string details, decimal amount, int status)
        {
            this.RequestID = requestID;
            FK_EmployeeID = fK_EmployeeID;
            Details = details;
            Amount = amount;
            Status = status;
        }

        public Guid RequestID {get; set;} 
        public Guid FK_EmployeeID {get; set;}
        public string Details {get; set;} 
        public decimal Amount {get; set;} 
        public int Status {get; set;}


    }
}