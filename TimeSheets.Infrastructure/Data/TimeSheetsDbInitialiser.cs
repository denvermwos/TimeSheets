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


            base.Seed(context);
        }
    }
}
