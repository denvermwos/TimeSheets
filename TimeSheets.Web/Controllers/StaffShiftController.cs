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

        public ActionResult Edit()
        {
            var viewModel = new StaffShiftEditViewModel();
            var staffShift = new StaffShift();
            return View(viewModel);
        }

        public PartialViewResult Sick(int id)
        {
            StaffShift staffShift = _staffShiftService.MarkShiftWithIdSick(id);
            return PartialView("_StaffShiftRow", staffShift);
        }

        public ActionResult Leave(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
