using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoLayer;

namespace BusinessLayer
{
    public class ReimbursementBusinessLayer
    {
        //creates repo layer instance
        private readonly ReimbursementRepoLayer _repoLayer;
        public ReimbursementBusinessLayer()
        {
            this._repoLayer = new ReimbursementRepoLayer();
        }
        //RequestsAsync method that calls repo layer method into list
        public async Task<List<Request>> RequestsAsync(int type)
        {
            List<Request> list = await this._repoLayer.RequestsAsync(type);
            return list;
        }
        //UpdateRequestsAsync method that calls ismanager async repo method to check status and if true it uses the repo update method to change status
        public async Task<UpdatedRequestDto> UpdateRequestsAsync(ApprovalDto approvalDto)
        {
            if (await this._repoLayer.IsManagerAsync(approvalDto.EmployeeID))
            {
                UpdatedRequestDto approvedRequest = await this._repoLayer.UpdateRequestsAsync(approvalDto.RequestID, approvalDto.Status);
                return approvedRequest;
            }
            else return null;
        }
        //used to check status and returns true if pending and false if other
        public async Task<bool> CheckForPendingAsync(Guid requestID)
        {
            return await this._repoLayer.CheckForPendingAsync(requestID);
            
        }
        //used to insert a row into the request db
        public async Task<Request> PostRequestsAsync(Request postRequest)
        {
            Request processedRequest = await this._repoLayer.PostRequestAsync(postRequest);
            return processedRequest;
        }

        public async Task<LoginDto> LoginAsync(LoginDto login)
        {
            LoginDto SuccessfulLogin = await this._repoLayer.LoginAsync(login);
            return SuccessfulLogin;
        }
    }
}
