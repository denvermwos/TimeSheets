using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheets.Core.Model;
using TimeSheets.Core.Services;
using TimeSheets.Web.ViewModels.ShiftVM;

namespace TimeSheets.Web.Controllers
{
    public class ShiftController : BaseController
    {
        private ShiftService _shiftService;

        public ShiftController(ShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        //
        // GET: /Shift/

        public ActionResult Index()
        {
            //todo list of shift for today
            IEnumerable<Shift> todayShifts = _shiftService.GetShifts(new Branch() { Id = 1, Name = "Verulam" }, DateTime.Today);
            ShiftIndexViewModel viewModel = new ShiftIndexViewModel();
            viewModel.ShiftList = todayShifts;
            return View(viewModel);
        }
        public ActionResult Date(DateTime dateTime)
        {
            //todo display shifts for specific day
            return View();
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            ShiftCreateViewModel viewModel = new ShiftCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Shift shift = new Shift() { BranchId = 1 };//todo get BranchId from logged in user after setting membership provider
            UpdateModel(shift);
            if (ModelState.IsValid)
            {
                _shiftService.CreateShift(shift);
                return RedirectToAction("Index");

            }
            else
            {
                ShiftCreateViewModel viewModel = new ShiftCreateViewModel();
                viewModel.Shift = shift;
                return View(viewModel);
            }
        }

        public ActionResult AddRemoveStaff()
        {
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }
    }
}
