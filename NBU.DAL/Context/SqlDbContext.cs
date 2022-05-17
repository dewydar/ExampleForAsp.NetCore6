using Microsoft.EntityFrameworkCore;
using NBU.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.Context
{
    public class SqlDbContext :DbContext
    {
        AppConfigrations appSetting = new AppConfigrations();
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Get Connection string from appsetting using appconfigratin class
                optionsBuilder.UseSqlServer(appSetting.sqlConnectionString);

            }
        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertification { get; set; }
        public DbSet<DocumentInfo> DocumentInfo { get; set; }
    }
}
