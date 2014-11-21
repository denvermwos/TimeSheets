using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            defaultStaff.Add(new Staff() { Id = 1, StaffNumber = 13, Name = "Denver Naidoo" });
            defaultStaff.Add(new Staff() { Id = 2, StaffNumber = 372, Name = "Rodney Reddy" });
            defaultStaff.Add(new Staff() { Id = 3, StaffNumber = 277, Name = "Shantal Govender" });
            foreach (Staff staff in defaultStaff)
            {
                context.Staff.Add(staff);
            }


            context.Branches.Add(new Branch() { Id = 1, Name = "Verulam" });

            IList<Shift> defaultShifts = new List<Shift>();
            defaultShifts.Add(new Shift() { BranchId = 1, StartDateTime = DateTime.Now, FinishDateTime = DateTime.Now.AddHours(4) });
            defaultShifts.Add(new Shift() { BranchId = 1, StartDateTime = DateTime.Now.AddHours(4), FinishDateTime = DateTime.Now.AddHours(8) });

            foreach (Shift shift in defaultShifts)
            {
                context.Shifts.Add(shift);
            }

            Device defaultDevice = new Device() { BranchId = 1, LastClearedTime = DateTime.Now };
            context.Devices.Add(defaultDevice);

            IList<Scan> defaultScans = new List<Scan>();
            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 1, ScanDateTime = DateTime.Now.AddMinutes(10) });
            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 1, ScanDateTime = DateTime.Now.AddMinutes(80) });
            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 1, ScanDateTime = DateTime.Now.AddMinutes(150) });
            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 1, ScanDateTime = DateTime.Now.AddMinutes(220) });

            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 2, ScanDateTime = DateTime.Now.AddMinutes(5) });
            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 2, ScanDateTime = DateTime.Now.AddMinutes(75) });
            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 3, ScanDateTime = DateTime.Now.AddMinutes(150) });
            defaultScans.Add(new Scan() { DeviceId = 1, StaffId = 3, ScanDateTime = DateTime.Now.AddMinutes(235) });


            foreach (Scan scan in defaultScans)
            {
                context.Scans.Add(scan);
            }

            StaffShift defaultStaffShift = new StaffShift() { ShiftId = 1, StaffId = 1, PaidStartTime = DateTime.Now, PaidFinishTime = DateTime.Now, };
            context.StaffShifts.Add(defaultStaffShift);
            ExecuteSqlScriptsToCreateStoredProcsAndFunctions(context);
            base.Seed(context);
        }

        private void ExecuteSqlScriptsToCreateStoredProcsAndFunctions(TimeSheetsContext context)
        {
            // Add Stored Procedures
            //foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Sql"), "*.sql"))
            var projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                .Parent.Parent.GetDirectories("TimeSheets.Infrastructure", SearchOption.AllDirectories)[0]
                .FullName;

            var sqlFilesDirectory = Path.Combine(projectDirectory, "Data\\Sql");

            var sqlFiles =
            Directory.GetFiles(sqlFilesDirectory, "*.sql");

            foreach (var file in sqlFiles)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file), new object[0]);
            }


        }
    }
}
