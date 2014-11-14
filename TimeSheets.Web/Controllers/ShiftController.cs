using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheets.Core.Model;
using TimeSheets.Core.Services;

namespace TimeSheets.Web.Controllers
{
    public class ShiftController : Controller
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
            IEnumerable<Shift> todayShifts = _shiftService.GetShifts(new Branch(){Id=1,Name= "Verulam"}, DateTime.Today);
            return View(todayShifts);
        }
        public ActionResult Date(DateTime dateTime)
        {
            //todo display shifts for specific day
            return View();
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Shift shift)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
