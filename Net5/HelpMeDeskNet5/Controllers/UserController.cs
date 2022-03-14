using Domain.service;
using HelpMeDeskNet5.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpMeDeskNet5.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IService _service;
        public UserController(IService service)
        {
            _service = service;
        }
        public IActionResult Index(int? id)
        {
            var viewModel = new UserListViewModel(_service.GetAllUsers());
            return View(viewModel);

        }
        public IActionResult Detail(int id)
        {
            var user = _service.GetUser((int)id);
            return View("Detail", user);
        }
    }
}
