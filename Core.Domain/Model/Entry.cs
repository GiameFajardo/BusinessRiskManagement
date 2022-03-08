using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Entry: UniqueEntity
    {
        public Guid FormId { get; set; }
        public Form Form { get; set; }
        public virtual ICollection<EntryMeta> EntryMetas { get; set; }
    }
}
