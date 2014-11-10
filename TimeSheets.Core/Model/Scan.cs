using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Scan
    {
        public int Id;
        public User User;
        public DateTime ScanDateTime;
        public Device Device;
    }
}
