using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Device
    {
        public Device()
        {
            Scans = new List<Scan>();
        }

        public int Id { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public string IpAddress { get; set; }
        public DateTime LastClearedTime { get; set; }

        public virtual ICollection<Scan> Scans { get; set; }
    }
}
