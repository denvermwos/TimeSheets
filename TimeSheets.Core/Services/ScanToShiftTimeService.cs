using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Services
{
    public class ScanToShiftTimeService
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public ScanToShiftTimeService(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public void AssignScansToShifts(IEnumerable<Scan> scans)
        {

        }
    }
}
