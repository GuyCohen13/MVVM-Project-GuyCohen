using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string eMail { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string LastName { get; set; }
    }
}
