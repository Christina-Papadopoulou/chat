using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityChat.Models
{
    public class UserModel
    {
        public UserModel() {

        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}