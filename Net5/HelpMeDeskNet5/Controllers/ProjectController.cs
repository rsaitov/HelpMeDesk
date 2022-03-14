using Domain.service;
using HelpMeDeskNet5.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private IService _service;
        public ProjectController(IService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var viewModel = new ProjectListViewModel(_service.GetAllProjects());
            return View(viewModel);
        }
        public IActionResult Detail(int id)
        {
            var user = _service.GetProject((int)id);
            return View("Detail", user);
        }
    }
}
