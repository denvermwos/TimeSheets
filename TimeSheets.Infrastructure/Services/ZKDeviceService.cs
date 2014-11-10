using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Services
{
    public class ZKDeviceService : IDeviceService
    {
        public bool ClearAttendanceLogs(Device device)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Scan> GetAllScans(Device device)
        {
            throw new NotImplementedException();
        }
    }
}
