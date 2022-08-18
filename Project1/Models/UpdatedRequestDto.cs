using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UpdatedRequestDto
    {
        public UpdatedRequestDto(Guid requestID, string firstName, string lastName, int status)
        {
            RequestID = requestID;
            FirstName = firstName;
            LastName = lastName;
            Status = status;
        }

        public Guid RequestID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }

    }
}
