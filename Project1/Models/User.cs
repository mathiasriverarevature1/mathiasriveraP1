using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
         //User ID and name
        public Guid EmployeeID {get; set;} = new Guid();
        public string Fname{ get; set; }
        public string Lname{ get; set; }

        //Username & password
        public string userName{ get; set; }
        public string password{ get; set; }
     
        //Role subordinate or manager
        public bool SupervisorStatus{get; set;} = false; //false is subordinate and true is manager
    }
}