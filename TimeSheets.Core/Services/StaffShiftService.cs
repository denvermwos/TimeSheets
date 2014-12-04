using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Services
{
    public class StaffShiftService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffShiftService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public StaffShift MarkShiftWithIdSick(int Id)
        {
            StaffShift staffShift = _unitOfWork.StaffShiftRepository.GetStaffShiftById(Id);
            staffShift.StaffSick = true;
            staffShift.StaffOnleave = false;
            _unitOfWork.StaffShiftRepository.UpdateStaffShift(staffShift);
            _unitOfWork.SaveChanges();
            return staffShift;
        }

    }
}
