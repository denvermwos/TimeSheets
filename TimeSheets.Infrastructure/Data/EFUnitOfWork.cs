using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Data
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private TimeSheetsContext _context = new TimeSheetsContext();
        private EFBranchRepository _branchRepository;
        private EFDeviceRepository _deviceRepository;
        private EFShiftRepository _shiftRepository;
        private EFStaffRepository _staffRepository;
        private EFUserRepository _userRepository;
        private EFScanRepository _scanRepository;

        public IBranchRepository BranchRepository
        {
            get
            {
                if (this._branchRepository == null)
                {
                    this._branchRepository = new EFBranchRepository(_context);
                }
                return _branchRepository;
            }
        }
        public IDeviceRepository DeviceRepository 
        {
            get
            {
                if (this._deviceRepository == null)
                {
                    this._deviceRepository = new EFDeviceRepository(_context);
                }
                return _deviceRepository;
            }
        }
        public IShiftRepository ShiftRepository 
        {
            get
            {
                if (this._shiftRepository == null)
                {
                    this._shiftRepository = new EFShiftRepository(_context);
                }
                return _shiftRepository;
            }
        }

        public IStaffRepository StaffRepository
        {
            get
            {
                if (this._staffRepository == null)
                {
                    this._staffRepository = new EFStaffRepository(_context);
                }
                return _staffRepository;
            }
        }
        public IUserRepository UserRepository 
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new EFUserRepository(_context);
                }
                return _userRepository;
            }
        }




        public IScanRepository ScanRepository
        {
            get
            {
                if (this._scanRepository == null)
                {
                    this._scanRepository = new EFScanRepository(_context);
                }
                return _scanRepository;
            }
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
