using System;
using System.Collections.Generic;
using System.Text;

namespace Scedulo.Shared.Models.Base
{
    public class AddingResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
