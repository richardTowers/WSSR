using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSSR.Controllers
{
	public class RunnerController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Run(long id)
		{
			System.Threading.Thread.Sleep(1000);
			return new JsonResult();
		}
	}
}
