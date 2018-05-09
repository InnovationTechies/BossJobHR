using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BossJob.Models
{
    public class CV
    {
        public int CVId { get; set; }
        public string CVLoc { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}