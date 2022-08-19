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

        /// <summary>
        /// puts request update and allows only managers to approve and deny requests while ensuring no consecutive changes can be made
        /// </summary>
        /// <param name="approval"></param>
        /// <returns></returns>
        [HttpPut("UpdateRequestsAsync")]
        public async Task<ActionResult<UpdatedRequestDto?>> UpdateRequestsAsync(ApprovalDto approval)
        {
            if (await this._businessLayer.CheckForPendingAsync(approval.RequestID) && ModelState.IsValid)
            {
                //send approval dto to business layer
                UpdatedRequestDto? approvedRequest = await this._businessLayer.UpdateRequestsAsync(approval);
                return Ok(approvedRequest);
            }
            else return Conflict(approval);//StatusCode(StatusCodes.Status409Conflict);    
        }

        /// <summary>
        /// Allows requests to be posted
        /// </summary>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        [HttpPost("PostRequestsAsync")]
        public async Task<ActionResult<Request>> PostRequestsAsync(Request postRequest)
        {
            if (ModelState.IsValid)
            {
                Request? processedRequest = await this._businessLayer.PostRequestsAsync(postRequest);
                return Ok(processedRequest);
            }
            else return Conflict(postRequest);
        }


        [HttpPost("LoginAsync")]
        public async Task<ActionResult<LoginDto?>> LoginAsync(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                LoginDto? SuccessfulLogin = await this._businessLayer.LoginAsync(login);
                return Ok(SuccessfulLogin);
            }
            return Conflict(login); 
       
        }
        

    }//EOC
}//EON
