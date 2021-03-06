﻿using System;
using System.Collections.Generic;
using TimeSheets.Core.Model;

namespace TimeSheets.Core.Interfaces
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAllStaff();
        IEnumerable<Staff> GetStaffAvailableToWorkThisShift(Shift shift);
    }
}
