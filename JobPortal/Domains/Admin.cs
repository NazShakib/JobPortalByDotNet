using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Domains
{
    public class Admin: BaseEntity
    {
        public string FullName { get; set; }
        public int Register_id { get; set; }
        public virtual Register Register { get; set; }
    }
}
