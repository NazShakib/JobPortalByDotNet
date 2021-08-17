using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Domains
{
    public class Register : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role RoleType { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
        public virtual JobPoster JobPoster { get; set; }
        public virtual Admin Admin { get; set; }

    }

    public enum Role
    {
        Admin=1,
        JobSeeker,
        JobPoster
    }
}
