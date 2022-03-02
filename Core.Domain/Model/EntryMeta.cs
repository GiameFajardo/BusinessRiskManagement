using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class EntryMeta: UniqueEntity
    {
        //public Guid FormId { get; set; }
        //public Form Form { get; set; }
        public Guid EntryId { get; set; }
        public Entry Entry { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
