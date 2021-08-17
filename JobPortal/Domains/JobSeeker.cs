using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Domains
{
    public class JobSeeker : BaseEntity
    {
        public string FullName { get; set; }
        public string Institute { get; set; }
        public string Image { get; set; }
        public string Cv { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Register_id { get; set; }
        public virtual ICollection<JobDetails> JobDetails { get; set; }
        public virtual Register Register { get; set; }
    }
}
