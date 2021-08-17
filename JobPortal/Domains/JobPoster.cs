using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Domains
{
    public class JobPoster : BaseEntity
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string Image { get; set; }
        public int Register_id { get; set; }
        public virtual ICollection<JobDetails> JobDetail { get; set; }
        public virtual Register Register { get; set; }
    }
}
