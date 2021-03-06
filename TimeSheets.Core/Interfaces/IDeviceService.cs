﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Interfaces
{
    public interface IDeviceService
    {
        IEnumerable<Scan> GetAllScans(Device device);
        bool ClearAttendanceLogs(Device device);

    }
}
