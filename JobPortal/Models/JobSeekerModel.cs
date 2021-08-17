using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class JobSeekerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Cv { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Register_id { get; set; }
    }
}
