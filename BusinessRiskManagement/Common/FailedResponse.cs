using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Common
{
    public abstract class FailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
