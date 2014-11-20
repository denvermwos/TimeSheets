using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;

namespace TimeSheets.Core.Services
{
    public class GetActualTimesFromScans
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public GetActualTimesFromScans(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public void ProcessScansForToday()
        {
            
        }
    }
}
