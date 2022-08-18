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

        private readonly ReimbursementRepoLayer _repoLayer;
        public ReimbursementBusinessLayer()
        {
            this._repoLayer = new ReimbursementRepoLayer();
        }

        public async Task<List<Request>> RequestsAsync(int type)
        {
            List<Request> list = await this._repoLayer.RequestsAsync(type);
            return list;
        }

        public async Task<Request> UpdateRequestsAsync(ApprovalDto approval)
        {
            if (await this._repoLayer.IsManagerAsync(approval.EmployeeID))
            {
                Request approvedRequest = await this._repoLayer.UpdateRequestsAsync(approval);
                return approvedRequest;
            }
            else return null;
        }
    }
}
