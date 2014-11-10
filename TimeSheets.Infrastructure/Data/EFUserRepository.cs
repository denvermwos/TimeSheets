using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;

namespace TimeSheets.Infrastructure.Data
{
    public class EFUserRepository : IUserRepository
    {
        private TimeSheetsContext _timeSheetsContext;
        public EFUserRepository(TimeSheetsContext timeSheetsContext)
        {
            _timeSheetsContext = timeSheetsContext;
        }
    }
}
