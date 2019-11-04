using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.Users
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
