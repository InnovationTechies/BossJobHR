using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BossJob.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobDesc { get; set; }
        public string JobExpire { get; set; }
        public virtual List<CV> CVs { get; set; }
    }
}