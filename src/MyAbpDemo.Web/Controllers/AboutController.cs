using System.Web.Mvc;

namespace MyAbpDemo.Web.Controllers
{
    public class AboutController : MyAbpDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}