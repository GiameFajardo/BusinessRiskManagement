using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Form: UniqueEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Meta { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
        //public virtual ICollection<EntryMeta> EntryMetas { get; set; }

    }
}
