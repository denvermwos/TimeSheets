using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;

namespace TimeSheets.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        //
        // GET: /Home/
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            IEnumerable<Staff> staff = _unitOfWork.StaffRepository.GetAllStaff();
            return View(staff);
        }

    }
}
