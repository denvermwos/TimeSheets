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
        IEnumerable<Shift> GetShiftsForDay(Branch branch, DateTime day);
        IEnumerable<Shift> GetAllShifts(); 
        void Create(Shift shift);

    }
}
