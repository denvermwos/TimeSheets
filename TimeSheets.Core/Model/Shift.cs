using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Model
{
    public class Shift
    {
        public Shift()
        {
            StaffShifts = new List<StaffShift>();
        }

        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<StaffShift> StaffShifts { get; set; }

    }
}
