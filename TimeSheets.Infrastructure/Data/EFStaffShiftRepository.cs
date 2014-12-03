using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;

namespace TimeSheets.Infrastructure.Data
{
    public class EFStaffShiftRepository : IStaffShiftRepository
    {

        public Core.Model.StaffShift GetStaffShiftInTimeRange(Core.Model.Scan scan)
        {
            throw new NotImplementedException();
        }
    }
}
