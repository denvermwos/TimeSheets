using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Device
    {
        public int Id;
        public Branch Branch;
        public string IpAddress;
        public DateTime LastClearedTime;
    }
}
