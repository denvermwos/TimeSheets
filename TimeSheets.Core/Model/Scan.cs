using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Scan
    {
        public int Id { get; set; }

        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }

        public DateTime ScanDateTime { get; set; }

    }
}
