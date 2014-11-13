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
        IEnumerable<Shift> GetShiftsForDay(DateTime day);
        void Create(Shift shift);

    }
}
