using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeSheets.Core.Model;
using TimeSheets.Web.ViewModels.SharedVM;

namespace TimeSheets.Web.ViewModels.ShiftVM
{
    public class ShiftAddRemoveViewModel : SharedLayoutViewModel
    {
        public Shift Shift { get; set; }
        public IEnumerable<Staff> AllStaff { get; set; } 
    }
}