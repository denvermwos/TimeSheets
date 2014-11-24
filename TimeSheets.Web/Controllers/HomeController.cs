using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheets.Core.Interfaces;
using TimeSheets.Core.Model;
using TimeSheets.Web.ViewModels.HomeVM;

namespace TimeSheets.Web.Controllers
{
    public class HomeController : BaseController
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
            var viewModel = new HomeIndexViewModel();
            viewModel.StaffList = staff;
            return View(viewModel);
            
        }

    }
}
