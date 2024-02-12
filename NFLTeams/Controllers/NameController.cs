using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)
        {
            if (model != null)
            {
                string userName = model.UserName;

                var session = new NFLSession(HttpContext.Session);
                session.SetUserName(userName);

                string activeConf = session.GetActiveConf();
                string activeDiv = session.GetActiveDiv();

                return RedirectToAction("Index", "Home", new { ActiveConf = activeConf, ActiveDiv = activeDiv});
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
