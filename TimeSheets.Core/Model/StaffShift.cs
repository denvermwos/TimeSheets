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
        public DateTime PaidStartTime { get; set; }
        public DateTime PaidFinishTime { get; set; }
        public bool NoSignInPenaltyApplied { get; set; }
        public bool NoSignOutPenaltyApplied { get; set; }
        public bool TookLunchBreak { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Shift Shift { get; set; }
        public bool StartTimeVerifiedWithScan { get; set; }
        public bool FinishTimeVerifiedWithScan { get; set; }
    }
}
