using Court_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Court_Application.Controllers
{
    public class WritController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Category = new List<SelectListItem>()
    {
        new SelectListItem { Text = "WP", Value = "WP" },
        new SelectListItem { Text = "Writ", Value = "Writ" },
        new SelectListItem { Text = "CRP", Value = "CRP" },

    };
            return View(new Writ_Document());
        }

    }
}
