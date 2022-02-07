using AutoMapper;
using Data;
using Domain;
using Domain.service;
using HelpMeDeskNet5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.Controllers
{
    public class TicketController : Controller
    {
        private IService _service;
        private IMapper _mapper;
        public TicketController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var tickets = _service.GetAllTickets();
            var model = new TicketListViewModel
            {
                Tickets = tickets
            };

            return View(model);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var ticket = _service.GetTicket(id.Value);
            var model = _mapper.Map<TicketViewModel>(ticket);

            return View(model);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket obj)
        {
            if (ModelState.IsValid)
            {
                _service.AddTicket(obj);
                return RedirectToAction("Detail");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return View(new TicketDTO());

            var ticket = _service.GetTicket(id.Value);
            var model = _mapper.Map<TicketViewModel>(ticket);
            model.TicketStatuses = _service.GetAllTicketStatuses();
            model.Projects = _service.GetAllProjects();
            model.Users = _service.GetAllUsers();

            return View(model);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TicketViewModel model)
        {
            var ticket = _mapper.Map<TicketDTO>(model);
            if (ModelState.IsValid)
            {
                ticket.LastChangedDate = DateTime.Now;
                _service.EditTicket(ticket);
                return RedirectToAction("Detail", new { id = ticket.Id });
            }
            return View(model);
        }
    }
}
