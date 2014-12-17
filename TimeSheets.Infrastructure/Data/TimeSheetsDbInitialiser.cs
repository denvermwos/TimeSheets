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
    public class TimeSheetsDbInitialiser : DropCreateDatabaseAlways<TimeSheetsContext>
    {
        protected override void Seed(TimeSheetsContext context)
        {
            var defaultStaff = new List<Staff>();
            defaultStaff.Add(new Staff() { Id = 1, StaffNumber = 13, Name = "Denver Naidoo" });
            defaultStaff.Add(new Staff() { Id = 2, StaffNumber = 372, Name = "Rodney Reddy" });
            defaultStaff.Add(new Staff() { Id = 3, StaffNumber = 277, Name = "Shantal Govender" });
            foreach (Staff staff in defaultStaff)
            {
                context.Staff.Add(staff);
            }


            context.Branches.Add(new Branch() { Id = 1, Name = "Verulam" });
            context.Branches.Add(new Branch() { Id = 2, Name = "Telebetting" });
            context.Branches.Add(new Branch() { Id = 3, Name = "Umhlanga" });

            var defaultShifts = new List<Shift>();
            defaultShifts.Add(new Shift() { BranchId = 1, StartDateTime = DateTime.Now, FinishDateTime = DateTime.Now.AddHours(4) });
            defaultShifts.Add(new Shift() { BranchId = 1, StartDateTime = DateTime.Now.AddHours(3), FinishDateTime = DateTime.Now.AddHours(7) });

            foreach (Shift shift in defaultShifts)
            {
                context.Shifts.Add(shift);
            }

            Device defaultDevice = new Device() { BranchId = 1, LastClearedTime = DateTime.Now };
            context.Devices.Add(defaultDevice);

            var defaultScans = new List<Scan>();
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




            var defaultStaffShifts = new List<StaffShift>();
            defaultStaffShifts.Add(new StaffShift()
            {
                ShiftId = 1,
                StaffId = 1,
                PaidStartTime = defaultShifts[0].StartDateTime.AddMinutes(10),
                PaidFinishTime = defaultShifts[0].FinishDateTime.AddMinutes(-35),
                //For Overridden time
                UseOverrideTimes = true,
                OPaidStartTime = defaultShifts[0].StartDateTime.AddMinutes(10),
                OPaidFinishTime = defaultShifts[0].FinishDateTime.AddMinutes(-35)

                
            });
            defaultStaffShifts.Add(new StaffShift()
            {
                ShiftId = 1,
                StaffId = 2,
                PaidStartTime = defaultShifts[0].StartDateTime.AddMinutes(45),
                PaidFinishTime = defaultShifts[0].FinishDateTime.AddMinutes(-25)
            });
            defaultStaffShifts.Add(new StaffShift()
            {
                ShiftId = 1,
                StaffId = 3,
                PaidStartTime = defaultShifts[0].StartDateTime.AddMinutes(15),
                PaidFinishTime = defaultShifts[0].FinishDateTime.AddMinutes(-5)
            });
            context.StaffShifts.AddRange(defaultStaffShifts);

            var defaultHolidays = getHolidayList();
            context.Holidays.AddRange(defaultHolidays);
            



            ExecuteSqlScriptsToCreateStoredProcsAndFunctions(context);
            base.Seed(context);
        }

        private IEnumerable<Holiday> getHolidayList()
        {
            var defaultHolidays = new List<Holiday>
            {
                new Holiday()
                {
                    Day = 1,
                    Month = 1,
                    Name = "New Years Day"
                },
                new Holiday()
                {
                    Day = 21,
                    Month = 3,
                    Name = "Human Rights Day"
                },
                new Holiday()
                {
                    Day = 18,
                    Month = 4,
                    Name = "Good Friday"
                },
                new Holiday()
                {
                    Day = 21,
                    Month = 4,
                    Name = "Family Day"
                },
                new Holiday()
                {
                    Day = 27,
                    Month = 4,
                    Name = "Freedom Day"
                },
                new Holiday()
                {
                    Day = 1,
                    Month = 5,
                    Name = "Workers Day"
                },
                new Holiday()
                {
                    Day = 1,
                    Month = 6,
                    Name = "Youth Day"
                },
                new Holiday()
                {
                    Day = 9,
                    Month = 8,
                    Name = "National Womens Day"
                },
                new Holiday()
                {
                    Day = 24,
                    Month = 9,
                    Name = "Heritage Day"
                },
                new Holiday()
                {
                    Day = 16,
                    Month = 12,
                    Name = "Day of Reconciliation"
                },
                new Holiday()
                {
                    Day = 25,
                    Month = 12,
                    Name = "Christmas Day"
                },
                new Holiday()
                {
                    Day = 26,
                    Month = 12,
                    Name = "Day of Goodwill"
                }
            };
            return defaultHolidays;
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
