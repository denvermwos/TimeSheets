using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;

namespace TimeSheets.Infrastructure.Data
{
    public class EFStaffRepository : IStaffRepository
    {
        private TimeSheetsContext _timeSheetsContext;
        public EFStaffRepository(TimeSheetsContext timeSheetsContext)
        {
            _timeSheetsContext = timeSheetsContext;
        }
    }
}
