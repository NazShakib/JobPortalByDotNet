using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Domains
{
    public class JobDetails : BaseEntity
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public JobTypes JobType { get; set; }
        public DateTime DeadlineAt { get; set; }
        public bool IsActive { get; set; }
        public string JobLocation { get; set; }
        public int NumberOfVacency { get; set; }
        public int JobPoster_id { get; set; }
        public virtual ICollection<JobSeeker> JobSeeker { get; set; }
        public virtual JobPoster JobPoster { get; set; }

    }


    public enum JobTypes
    {
        Engineering,
        Commerce,
        NonTechnical,
        Others
    }
}
