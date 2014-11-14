using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Data
{
    class TimeSheetsDbInitialiser : DropCreateDatabaseAlways<TimeSheetsContext>
    {
        protected override void Seed(TimeSheetsContext context)
        {
            IList<Staff> defaultStaff = new List<Staff>();
            defaultStaff.Add(new Staff(){Id = 13, Name = "Denver Naidoo"});
            defaultStaff.Add(new Staff() { Id = 372, Name = "Rodney Reddy" });
            defaultStaff.Add(new Staff() { Id = 277, Name = "Shantal Govender" });
            foreach (Staff staff in defaultStaff)
            {
                context.Staff.Add(staff);
            }


            context.Branches.Add(new Branch() {Id = 1,Name = "Verulam"});

            IList<Shift> defaultShifts  = new List<Shift>();
            defaultShifts.Add(new Shift(){BranchId = 1, StartDateTime = DateTime.Now, FinishDateTime = DateTime.Now.AddHours(4)});
            defaultShifts.Add(new Shift() { BranchId = 1, StartDateTime = DateTime.Now.AddHours(4), FinishDateTime = DateTime.Now.AddHours(8) });
            foreach (Shift shift in defaultShifts)
            {
                context.Shifts.Add(shift);
            }

            base.Seed(context);
        }
    }
}
