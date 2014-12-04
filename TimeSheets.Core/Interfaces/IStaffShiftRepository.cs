using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Interfaces
{
    public interface IStaffShiftRepository
    {
        StaffShift GetStaffShiftInTimeRange(Scan scan);
        StaffShift GetStaffShiftById(int id);
        void UpdateStaffShift(StaffShift staffShift);
    }
}
