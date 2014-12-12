using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayName("Start Time")]
        public DateTime? PaidStartTime { get; set; }
        [DisplayName("Finish Time")]
        public DateTime? PaidFinishTime { get; set; }

        public bool TookLunchBreak { get; set; }
        public bool StaffOnleave { get; set; }
        public bool StaffSick { get; set; }

        [NotMapped]
        public TimeSpan LunchBreakDuration
        {
            get { return TimeSpan.FromTicks(LunchBreakDurationTicks); }
            set { LunchBreakDurationTicks = value.Ticks; }
        }

        public Int64 LunchBreakDurationTicks { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
        public virtual Shift Shift { get; set; }

        public bool DoNotDelete { get; set; }

        public Boolean UseOverrideTimes { get; set; }

        [DisplayName("Start Time")]
        public DateTime? OPaidStartTime { get; set; }

        [DisplayName("Finish Time")]
        public DateTime? OPaidFinishTime { get; set; }

        public float NormalHours { get; set; }
        public float SundayHours { get; set; }
        public float PublicHolidayHours { get; set; }
        public float AttendanceBonusHours { get; set; }

        public void ResetToNormal()
        {
            StaffOnleave = false;
            StaffSick = false;
            UseOverrideTimes = false;
        }

        
        
    }
}
