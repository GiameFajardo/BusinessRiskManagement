using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRiskManagement.Common
{
    public abstract class SussessResponse<T>
    {
        public List<T> Result { get; set; }
    }
}
