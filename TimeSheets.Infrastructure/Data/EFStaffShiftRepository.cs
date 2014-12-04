using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Data
{
    public class EFStaffShiftRepository : IStaffShiftRepository
    {
        private TimeSheetsContext _timeSheetsContext;
        public EFStaffShiftRepository(TimeSheetsContext timeSheetsContext)
        {
            _timeSheetsContext = timeSheetsContext;
        }

        public StaffShift GetStaffShiftInTimeRange(Core.Model.Scan scan)
        {
            throw new NotImplementedException();
        }



        public StaffShift GetStaffShiftById(int id)
        {
            StaffShift staffShift = _timeSheetsContext.StaffShifts.FirstOrDefault(ss => ss.Id == id);
            return staffShift;
        }

        public void UpdateStaffShift(StaffShift staffShift)
        {
            if (staffShift != null)
            {
                _timeSheetsContext.Entry(staffShift).State = EntityState.Modified;
            }
        }
    }
}
