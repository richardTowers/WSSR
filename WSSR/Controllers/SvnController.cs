using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSSR.Controllers
{
    public class SvnController : Controller
    {

        public ActionResult Update()
        {
			Thread.Sleep(1000);
			return new JsonResult {
				Data = new { Result = "Config updated successfully." },
				JsonRequestBehavior = JsonRequestBehavior.AllowGet
			};
        }

    }
}
