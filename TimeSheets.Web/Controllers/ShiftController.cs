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
        private StaffService _staffService;
        private BranchService _branchService;

        public ShiftController(ShiftService shiftService, StaffService staffService, BranchService branchService)
        {
            _branchService = branchService;
            _shiftService = shiftService;
            _staffService = staffService;
        }

        //
        // GET: /Shift/
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index_Get(DateTime? id)
        {
            //todo list of shift for today
            var dateToGetShiftsFor = new DateTime();
            if (id == null)
            {
                dateToGetShiftsFor = DateTime.Today;
            }
            else
            {
                dateToGetShiftsFor = (DateTime) id;
            }
            IEnumerable<Shift> todayShifts = _shiftService.GetShifts(1, dateToGetShiftsFor);
            var viewModel = new ShiftIndexViewModel();
            viewModel.ShiftList = todayShifts;
            viewModel.DateBeingViewed = dateToGetShiftsFor;
            viewModel.BranchSelectList = new SelectList(_branchService.GetAllBranches(),"Id","Name");
            return View(viewModel);
        }
        
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(DateTime dateBeingViewed, int branchId)
        {
            //todo list of shift for today
            IEnumerable<Shift> todayShifts = _shiftService.GetShifts(branchId, dateBeingViewed);
            var viewModel = new ShiftIndexViewModel();
            viewModel.ShiftList = todayShifts;
            viewModel.DateBeingViewed = dateBeingViewed;
            viewModel.BranchSelectList = new SelectList(_branchService.GetAllBranches(),"Id","Name");
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
        public ActionResult Create_Post(Shift shift)
        {
            shift.BranchId = 1;
            if (ModelState.IsValid)
            {
                _shiftService.CreateShift(shift);
                return RedirectToAction("Index");
                
            }
            else
            {
                var viewModel = new ShiftCreateViewModel {Shift = shift};
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
