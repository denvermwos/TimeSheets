using System;
using System.Collections.Generic;
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

        public IEnumerable<Core.Model.Shift> GetShiftsForDay(Branch branch,DateTime day)
        {
            return _timeSheetsContext.Shifts.Where(x => x.StartDateTime.Year == day.Year && x.StartDateTime.Month == day.Month && x.StartDateTime.Day == day.Day && x.BranchId == branch.Id).ToList();
            
        }

        public void Create(Core.Model.Shift shift)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Shift> GetAllShifts()
        {
            return _timeSheetsContext.Shifts.ToList();
        }
    }
}
