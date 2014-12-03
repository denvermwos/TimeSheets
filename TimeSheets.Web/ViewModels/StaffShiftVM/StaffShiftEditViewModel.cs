using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeSheets.Core.Model;
using TimeSheets.Web.ViewModels.SharedVM;

namespace TimeSheets.Web.ViewModels.StaffShiftVM
{
    public class StaffShiftEditViewModel : SharedLayoutViewModel
    {
        public StaffShift StaffShift { get; set; }
    }
}