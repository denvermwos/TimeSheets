using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Infrastructure.Data
{
    public class EFStaffRepository : IStaffRepository
    {
        private TimeSheetsContext _timeSheetsContext;
        public EFStaffRepository(TimeSheetsContext timeSheetsContext)
        {
            _timeSheetsContext = timeSheetsContext;
        }

        public IEnumerable<Core.Model.Staff> GetAllStaff()
        {
            return _timeSheetsContext.Staff.ToList();
        }


        public IEnumerable<Core.Model.Staff> GetStaffAvailableToWorkThisShift(Shift shift)
        {
            //todo remove code smell
            //return _timeSheetsContext.Staff.Where(
            //    s =>
            //        s.StaffShifts.Count(ss =>

            //            ((ss.Shift.FinishDateTime <= shift.StartDateTime && ss.Shift.FinishDateTime >= shift.FinishDateTime) && ss.ShiftId != shift.Id) ||
            //            ((ss.Shift.StartDateTime <= shift.StartDateTime && ss.Shift.FinishDateTime <= shift.FinishDateTime) && ss.ShiftId != shift.Id) ||
            //            ((ss.Shift.StartDateTime >= shift.StartDateTime && ss.Shift.FinishDateTime >= shift.FinishDateTime) && ss.ShiftId != shift.Id) ||
            //            ((ss.Shift.StartDateTime >= shift.StartDateTime && ss.Shift.FinishDateTime <= shift.FinishDateTime) && ss.ShiftId != shift.Id)


            //            ) == 0).ToList();
            var result = _timeSheetsContext.Staff.Include(s => s.StaffShifts).Where(
                s =>
                    !s.StaffShifts.Any(
                    ss => (
                        
                            ((ss.Shift.FinishDateTime >= shift.StartDateTime && ss.Shift.FinishDateTime <= shift.FinishDateTime) && ss.ShiftId != shift.Id) ||
                            ((ss.Shift.StartDateTime <= shift.StartDateTime && ss.Shift.FinishDateTime >= shift.FinishDateTime) && ss.ShiftId != shift.Id) ||
                            ((ss.Shift.StartDateTime >= shift.StartDateTime && ss.Shift.FinishDateTime <= shift.FinishDateTime) && ss.ShiftId != shift.Id) ||
                            ((ss.Shift.StartDateTime >= shift.StartDateTime && ss.Shift.FinishDateTime >= shift.FinishDateTime) && ss.ShiftId != shift.Id)
                           )
                                            
                                            
                                            ));


            return result;


            //return _timeSheetsContext.Staff.Where(s => s.Id == 1).ToList();
        }

    }
}
