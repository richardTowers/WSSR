using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WSSR.Controllers
{
    public class ScriptsController : Controller
    {
        public ActionResult Index()
        {
			var factory = new ScriptRunner.Factory();
			var scriptGetter = factory.ScriptGetter;
			return new JsonResult {
				Data = scriptGetter.GetScripts(),
				JsonRequestBehavior = JsonRequestBehavior.AllowGet,
			};
        }

    }
}
