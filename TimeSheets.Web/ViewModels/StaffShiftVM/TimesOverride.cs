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
        [DisplayName("Start")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]

        public DateTime? OPaidStartTime { get; set; }//made these nullable due to use of textboxfor to display date, if wasnt nullable then textboxfor would display a date for null values

        [Required]
        [DisplayName("Finish")]
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