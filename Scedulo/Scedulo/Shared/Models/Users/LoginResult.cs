using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.Users
{
    public class LoginResult
    {
        public string UserId { get; set; }
        public bool Successful { get; set; }
        public int MyProperty { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
