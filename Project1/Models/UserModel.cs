using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
         //User ID
        public int userID{ get; set; }
        public string Fname{ get; set; }
        public string Lname{ get; set; }

        //Username
        public string userName{ get; set; }
        //Password
        public string password{ get; set; }
     
        //Role subordinate or manager? maybe child classes
    }
}