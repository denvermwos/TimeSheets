using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TimeSheets.Core.Model;

namespace TimeSheets.Web.ViewModels.StaffShiftVM
{
    public class TimesOverride
    {
        [Required]
        public int StaffShiftId { get; set; }

        [Required]
        [DisplayName("Paid Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? OPaidStartTime { get; set; }

        [Required]
        [DisplayName("Paid Finish Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? OPaidFinishTime { get; set; }

        public void SetTimesToStaffShiftForDisplay(StaffShift staffShift)
        {
            StaffShiftId = staffShift.Id;
            if (staffShift.UseOverrideTimes)
            {
                if (staffShift.OPaidStartTime != null)
                {
                    OPaidStartTime = (DateTime)staffShift.OPaidStartTime;
                }

                if (staffShift.OPaidFinishTime != null)
                {
                    OPaidFinishTime = (DateTime)staffShift.OPaidFinishTime;
                }
            }
        }
    }
}