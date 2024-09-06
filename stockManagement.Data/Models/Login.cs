using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Data.Models
{
    public class Login : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
