using Microsoft.AspNetCore.Mvc;

namespace Court_Application.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
