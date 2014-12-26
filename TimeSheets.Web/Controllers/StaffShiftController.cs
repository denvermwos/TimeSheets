using System.Web.Mvc;
using TimeSheets.Core.Model;
using TimeSheets.Core.Services;
using TimeSheets.Web.ViewModels.StaffShiftVM;

namespace TimeSheets.Web.Controllers
{
    public class StaffShiftController : BaseController
    {
        private readonly StaffShiftService _staffShiftService;

        public StaffShiftController(StaffShiftService staffShiftService)
        {
            _staffShiftService = staffShiftService;
        }

        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(TimesOverride timesOverride)
        {
            if (timesOverride.OPaidStartTime.Value.AddHours(1) >= timesOverride.OPaidFinishTime.Value)
            {
                ModelState.AddModelError(string.Empty, "Shift has to be longer than an hour");
                var viewModel = new StaffShiftEditViewModel();
                StaffShift staffShift = _staffShiftService.GetStaffShiftById(timesOverride.StaffShiftId);
                viewModel.StaffShift = staffShift;
                return View(viewModel);
            }
            if (ModelState.IsValid)
            {
                _staffShiftService.ApplyOverrideTimes(timesOverride.StaffShiftId, timesOverride.OPaidStartTime, timesOverride.OPaidFinishTime);
                return RedirectToAction("Index", "Shift");
            }
            else
            {
                var viewModel = new StaffShiftEditViewModel();
                StaffShift staffShift = _staffShiftService.GetStaffShiftById(timesOverride.StaffShiftId);
                viewModel.StaffShift = staffShift;
                return View(viewModel);  
            }
            
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            var viewModel = new StaffShiftEditViewModel();
            var staffShift = _staffShiftService.GetStaffShiftById(id);
            var timesOverride = new TimesOverride();
            timesOverride.SetTimesToStaffShiftForDisplay(staffShift);
            viewModel.StaffShift = staffShift;
            viewModel.TimesOverride = timesOverride;
            
            return View(viewModel);
        }

        [HttpPost]
        public PartialViewResult Sick(int id)
        {
            Latency();
            StaffShift staffShift = _staffShiftService.MarkShiftWithIdSick(id);
            return PartialView("_StaffShiftRow", staffShift);
        }

        [HttpPost]
        public ActionResult NotSick(int id)
        {
            Latency();
            StaffShift staffShift = _staffShiftService.MarkShiftWithIdNotSick(id);
            return PartialView("_StaffShiftRow", staffShift);
        }

        [HttpPost]
        public ActionResult OnLeave(int id)
        {
            Latency();
            StaffShift staffShift = _staffShiftService.MarkShiftWithIdOnLeave(id);
            return PartialView("_StaffShiftRow", staffShift);
        }

        [HttpPost]
        public ActionResult NotOnLeave(int id)
        {
            Latency();
            StaffShift staffShift = _staffShiftService.MarkShiftWithIdNotOnLeave(id);
            return PartialView("_StaffShiftRow", staffShift);
        }
        

        

        private void Latency()
        {
            //todo fake latency remove this before going to production
            //System.Threading.Thread.Sleep(1000);
        }

        public ActionResult RemOTimes(TimesOverride timesOverride)
        {
            _staffShiftService.RemoveOverridingTimes(timesOverride.StaffShiftId);
            return RedirectToAction("Index", "Shift");
        }
    }
}
