using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Services
{
    public class ShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        //todo shift service implementation
        public ShiftService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Shift> GetShifts(int branchId, DateTime dateTime)
        {
            return _unitOfWork.ShiftRepository.GetShiftsForDay(branchId, dateTime);
        }

        

        public bool DeleteShift()
        {
            return true;
        }

        public void CreateShift(Shift shift)
        {
            _unitOfWork.ShiftRepository.Create(shift);
            _unitOfWork.SaveChanges();
        }

        public Shift GetShiftForAddRemoveStaff(int id)
        {
            return _unitOfWork.ShiftRepository.GetShiftByIdIncludeStaff(id);
        }

        public void AddStaffWithGivenIdsToShift(IEnumerable<int> staffIdList,int shiftId)
        {
            _unitOfWork.ShiftRepository.AddStaffToShift(staffIdList,shiftId);
            _unitOfWork.SaveChanges();
        }

        public void RemoveStaffWithGivenIdsFromShift(IEnumerable<int> staffIdList, int shiftId)
        {
            _unitOfWork.ShiftRepository.RemoveStaffFromShift(staffIdList, shiftId);
            _unitOfWork.SaveChanges();
        }




    }
}
