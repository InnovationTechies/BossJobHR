using BossJob.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace BossJob.Context
{
    public class JobContext:DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<CV> CVs { get; set; }
    }
}