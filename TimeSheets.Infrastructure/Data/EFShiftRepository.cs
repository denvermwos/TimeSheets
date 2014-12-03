using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Data
{
    public class EFShiftRepository : IShiftRepository
    {
        private TimeSheetsContext _timeSheetsContext;
        public EFShiftRepository(TimeSheetsContext timeSheetsContext)
        {
            _timeSheetsContext = timeSheetsContext;
        }

        public IEnumerable<Shift> GetShiftsForDay(Branch branch, DateTime day)
        {
            return _timeSheetsContext.Shifts.Include("StaffShifts.Staff").Where(x => x.StartDateTime.Year == day.Year && x.StartDateTime.Month == day.Month && x.StartDateTime.Day == day.Day && x.BranchId == branch.Id).ToList();

        }

        public void Create(Shift shift)
        {
            _timeSheetsContext.Shifts.Add(shift);
        }



        public IEnumerable<Shift> GetAllShifts()
        {
            return _timeSheetsContext.Shifts.ToList();
        }


        public Shift GetShiftByIdIncludeStaff(int id)
        {
            return _timeSheetsContext.Shifts.Include("StaffShifts.Staff").FirstOrDefault(x => x.Id == id);
        }


        public void AddStaffToShift(IEnumerable<int> staffIds, int shiftId)
        {
            var staffShifts = new List<StaffShift>();
            Shift shift = _timeSheetsContext.Shifts.FirstOrDefault(s => s.Id == shiftId);
            if (shift != null && staffIds != null)
            {
                staffShifts = staffIds.Select(sId => new StaffShift()
                {
                    ShiftId = shiftId,
                    
                    StaffId = sId
                }).ToList();

                _timeSheetsContext.StaffShifts.AddRange(staffShifts);
            }
        }


        public void RemoveStaffFromShift(IEnumerable<int> staffIds, int shiftId)
        {
            //todo optimise the delete operation with sql
            if (staffIds != null && shiftId != null)
            {
                var staffShiftsToRemove = new List<StaffShift>();
                foreach (var sId in staffIds)
                {
                    staffShiftsToRemove.Add(
                        _timeSheetsContext.StaffShifts.FirstOrDefault(ss => ss.StaffId == sId && ss.ShiftId == shiftId));
                }
                _timeSheetsContext.StaffShifts.RemoveRange(staffShiftsToRemove);
            }
        }
    }
}
