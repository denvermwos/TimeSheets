using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Shift> GetShifts(DateTime dateTime)
        {
            return new List<Shift>();
        }

        public bool DeleteShift()
        {
            return true;
        }

        public bool AddShift(Shift shift)
        {
            return true;
        }

    }
}
