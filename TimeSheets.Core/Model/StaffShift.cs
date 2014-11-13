using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class StaffShift
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int ShiftId { get; set; }
        public DateTime ActualStartTime { get; set; }
        public DateTime ActualFinishTime { get; set; }
        public bool TookLunchBreak { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
