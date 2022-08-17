using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ReimbursementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseReimbursement : ControllerBase
    {
        [HttpGet("PendingTickets")]
        public async ActionResult<List<Ticket>> PendingRequests()
        {
            if(Type.Equals("pending")
                {
                List<Ticket> ticketList = new List<Ticket>();
                return ticket;
                }
        }
    }//EOC
}//EON
