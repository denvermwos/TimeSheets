using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Services
{
    public class StaffService
    {
        private IUnitOfWork _iUnitOfWork;

        public StaffService(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            return _iUnitOfWork.StaffRepository.GetAllStaff();
        }
        public IEnumerable<Staff> GetStaffAvailableToWorkThisShift(Shift shift)
        {
            return _iUnitOfWork.StaffRepository.GetStaffAvailableToWorkThisShift(shift);
        }
    }
}
