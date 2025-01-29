using Microsoft.AspNetCore.Mvc;

namespace Court_Application.Controllers
{
	public class UserController : Controller
	{	

		public IActionResult UserHome()
		{
			return View();
		}

		public IActionResult LogOut()
		{
			return RedirectToAction("Logout", "Login");
		}
	}
}
