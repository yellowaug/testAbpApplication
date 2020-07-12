using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MyAbpDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyAbpDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}