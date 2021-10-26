using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoApplication.Models
{
    public class DemoApplicationDbContext : DbContext
    {
        public DemoApplicationDbContext() : base("DemoApplicationDb")
        {

        }

        public DbSet<Employees> Employeess { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDetail> ProjectDetails { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}