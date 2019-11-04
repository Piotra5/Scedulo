using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.Users
{
    public class UserModel
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime? DoB { get; set; }
        public bool IsEmployed { get; set; } = false;
    }
}
