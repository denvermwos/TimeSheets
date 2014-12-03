using System.Web.Mvc;
using TimeSheets.Core.Model;
using TimeSheets.Web.ViewModels.StaffShiftVM;

namespace TimeSheets.Web.Controllers
{
    public class StaffShiftController : BaseController
    {
        //
        // GET: /StaffShift/

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

    }
}
