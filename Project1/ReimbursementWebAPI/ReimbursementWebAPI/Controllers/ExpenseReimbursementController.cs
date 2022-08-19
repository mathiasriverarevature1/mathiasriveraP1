using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLayer;

namespace ReimbursementWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseReimbursementController : ControllerBase
    {
        //creates intance of business layer class
        private readonly ReimbursementBusinessLayer _businessLayer;
        public ExpenseReimbursementController()
        {
            this._businessLayer = new ReimbursementBusinessLayer();
        }

        /// <summary>
        /// Get all the pending requests by filtering types
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

        [HttpPut("UpdateRequestsAsync")]
        public async Task<ActionResult<UpdatedRequestDto>> UpdateRequestsAsync(ApprovalDto approval)
        {
            if (await this._businessLayer.CheckForPending(approval.RequestID) && ModelState.IsValid)
            {
                //send approval dto to business layer
                UpdatedRequestDto approvedRequest = await this._businessLayer.UpdateRequestsAsync(approval);
                return Ok(approvedRequest);
            }
            else return Conflict(approval);//StatusCode(StatusCodes.Status409Conflict);    
        }


    }//EOC
}//EON
