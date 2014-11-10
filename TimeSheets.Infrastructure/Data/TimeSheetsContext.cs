using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Data
{
    public class TimeSheetsContext : DbContext
    {
        public TimeSheetsContext() : base("TimeSheetsDb")
        {
            
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Scan> Scans { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
