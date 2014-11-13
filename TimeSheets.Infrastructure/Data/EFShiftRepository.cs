using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;

namespace TimeSheets.Infrastructure.Data
{
    public class EFShiftRepository : IShiftRepository
    {
        private TimeSheetsContext _timeSheetsContext;
        public EFShiftRepository(TimeSheetsContext timeSheetsContext)
        {
            _timeSheetsContext = timeSheetsContext;
        }

        public IEnumerable<Core.Model.Shift> GetShiftsForDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public void Create(Core.Model.Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}
