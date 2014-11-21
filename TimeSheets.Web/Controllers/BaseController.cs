using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheets.Web.ViewModels.SharedVM;

namespace TimeSheets.Web.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var baseModel = filterContext.Controller.ViewData.Model as SharedLayoutViewModel;
            if (baseModel != null)
            {
                baseModel.Name = "Denver Naidoo";
            }
            base.OnResultExecuting(filterContext);
        }

    }
}
