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
        private readonly StaffService _staffService;

        public ShiftController(ShiftService shiftService, StaffService staffService)
        {
            _shiftService = shiftService;
            _staffService = staffService;
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
                var viewModel = new ShiftCreateViewModel();
                viewModel.Shift = shift;
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult AddRemoveStaff(int id)
        {
            var viewModel = new ShiftAddRemoveViewModel();
            Shift shift = _shiftService.GetShiftForAddRemoveStaff(id);
            viewModel.Shift = shift;
            viewModel.StaffAvailableForShift = _staffService.GetStaffAvailableToWorkThisShift(shift);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddRemoveStaff(ICollection<int> staffIdsToAdd, ICollection<int> staffIdsToRemove, int shiftId)
        {
            _shiftService.AddStaffWithGivenIdsToShift(staffIdsToAdd, shiftId);
            _shiftService.RemoveStaffWithGivenIdsFromShift(staffIdsToRemove, shiftId);

            return RedirectToAction("Index");
        }



    }
}
