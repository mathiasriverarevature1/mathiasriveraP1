using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Ticket
    {
        public Guid TicketID {get; set;} = new Guid();//ID- from Employee
        public string TicketDescription {get; set;} //Description- Allow Type of expense
        public string Status {get; set;} //Status- Approved, pending, or denied
        public decimal TicketAmount {get; set;} //Amount - Allow amount insertion


    }
}