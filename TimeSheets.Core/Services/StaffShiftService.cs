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

        public StaffShift MarkShiftWithIdSick(int id)
        {
            StaffShift staffShift = _unitOfWork.StaffShiftRepository.GetStaffShiftById(id);
            staffShift.ResetToNormal();
            staffShift.StaffSick = true;
            _unitOfWork.StaffShiftRepository.UpdateStaffShift(staffShift);
            _unitOfWork.SaveChanges();
            return staffShift;
        }
        public StaffShift MarkShiftWithIdNotSick(int id)
        {
            StaffShift staffShift = _unitOfWork.StaffShiftRepository.GetStaffShiftById(id);
            staffShift.ResetToNormal();
            _unitOfWork.StaffShiftRepository.UpdateStaffShift(staffShift);
            _unitOfWork.SaveChanges();
            return staffShift;
        }
        public StaffShift MarkShiftWithIdOnLeave(int id)
        {
            StaffShift staffShift = _unitOfWork.StaffShiftRepository.GetStaffShiftById(id);
            staffShift.ResetToNormal();
            staffShift.StaffOnleave = true;
            _unitOfWork.StaffShiftRepository.UpdateStaffShift(staffShift);
            _unitOfWork.SaveChanges();
            return staffShift;
        }
        public StaffShift MarkShiftWithIdNotOnLeave(int id)
        {
            StaffShift staffShift = _unitOfWork.StaffShiftRepository.GetStaffShiftById(id);
            staffShift.ResetToNormal();
            _unitOfWork.StaffShiftRepository.UpdateStaffShift(staffShift);
            _unitOfWork.SaveChanges();
            return staffShift;
        }

        public void ApplyOverrideTimes(int staffShiftId, DateTime? oPaidStartTime, DateTime? oPaidFinishTime)
        {
            StaffShift staffShiftFromDb =_unitOfWork.StaffShiftRepository.GetStaffShiftById(staffShiftId);
            staffShiftFromDb.ResetToNormal();
            staffShiftFromDb.UseOverrideTimes = true;
            staffShiftFromDb.OPaidStartTime = oPaidStartTime;
            staffShiftFromDb.OPaidFinishTime = oPaidFinishTime;
            _unitOfWork.StaffShiftRepository.UpdateStaffShift(staffShiftFromDb);
            _unitOfWork.SaveChanges();
        }

        public void RemoveOverridingTimes(int staffShiftId)
        {
            StaffShift staffShiftFromDb = _unitOfWork.StaffShiftRepository.GetStaffShiftById(staffShiftId);

            staffShiftFromDb.ResetToNormal();
            _unitOfWork.StaffShiftRepository.UpdateStaffShift(staffShiftFromDb);
            _unitOfWork.SaveChanges();
        }

        public StaffShift GetStaffShiftById(int id)
        {
            return _unitOfWork.StaffShiftRepository.GetStaffShiftById(id);
        }
    }
}
