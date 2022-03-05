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
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                var viewModel = new ProjectListViewModel(_service.GetAllProjects());
                return View(viewModel);
            }

            var user = _service.GetProject((int)id);
            return View("Detail", user);
        }
    }
}
