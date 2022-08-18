using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLayer;

namespace ReimbursementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseReimbursementController : ControllerBase
    {
        private readonly ReimbursementBusinessLayer _businessLayer;
        public ExpenseReimbursementController()
        {
            this._businessLayer = new ReimbursementBusinessLayer();
        }

        /// <summary>
        /// Get all the pending requests
        /// </summary>
        /// <returns></returns>
        [HttpGet("RequestsAsync")]
        [HttpGet("RequestsAsync/{type}")]
        //[HttpGet("RequestsAsync/{type}/{id}")]
        //[HttpGet("RequestAsync/{id}")]
        public async Task<ActionResult<List<Request>>> RequestsAsync(int type, Guid? id)
        {
          
                List<Request> requestList = await this._businessLayer.RequestsAsync(type);
                return Ok(requestList);//returns 200
                
                //return null;
        }

        [HttpPut("UpdateRequestAsync")]
        public async Task<ActionResult<Request>> UpdateRequestAsync(ApprovalDto approval)
        {
            //send approval dto to business layer
            Request approvedRequest = await this._businessLayer.UpdateRequestsAsync(approval);
        }

    }//EOC
}//EON
