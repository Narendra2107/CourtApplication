using Court_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace Court_Application.Controllers
{
	public class LoginController : Controller
	{
		private readonly string _filePath = "";

		private IConfiguration _config;

		public LoginController(IConfiguration config)
		{
			_config = config;
			_filePath = _config.GetValue<string>("UserFilePath");
		}


		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(string email, string password)
		{
			var users = LoadUsers();
			var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

			if (user != null)
			{
				return RedirectToAction("UserHome", "User");
			}
			else
			{
				ViewBag.Error = "Invalid username or password";
				return View();
			}
		}

		
		public IActionResult Logout()
		{
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public IActionResult Register(string name, string email, string phone, string password)
		{
			var users = LoadUsers();
			if (users.Any(u => u.Email == email))
			{
				ViewBag.Error = "Email already registered";
				return View("Index");
			}

			var newUser = new User
			{
				Id = users.Any() ? users.Max(u => u.Id) + 1 : 1,
				Name = name,
				Email = email,
				Phone = phone,
				Password = password
			};

			users.Add(newUser);
			SaveUsers(users);

			return RedirectToAction("Index", "Home");
		}

		private List<User> LoadUsers()
		{
			if (!System.IO.File.Exists(_filePath))
			{
				return new List<User>();
			}

			var json = System.IO.File.ReadAllText(_filePath);
			return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
		}

		private void SaveUsers(List<User> users)
		{
			var json = JsonSerializer.Serialize(users);
			System.IO.File.WriteAllText(_filePath, json);
		}

		
		public IActionResult Register()
		{
			return View();
		}
	}
}
