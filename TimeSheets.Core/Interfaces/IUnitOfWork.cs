using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBranchRepository BranchRepository { get; }
        IDeviceRepository DeviceRepository { get; }
        IShiftRepository ShiftRepository { get; }
        IStaffRepository StaffRepository { get; }
        IUserRepository UserRepository { get; }
        IScanRepository ScanRepository { get; }
        IStaffShiftRepository StaffShiftRepository { get; }

        void SaveChanges();
    }
}
