using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Interfaces
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetShiftsForDay(int branchId, DateTime day);
        IEnumerable<Shift> GetAllShifts(); 
        void Create(Shift shift);
        Shift GetShiftByIdIncludeStaff(int id);
        void AddStaffToShift(IEnumerable<int> staffIds,int shiftId);


        void RemoveStaffFromShift(IEnumerable<int> staffIds, int shiftId);
    }
}
