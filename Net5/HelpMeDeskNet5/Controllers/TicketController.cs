using AutoMapper;
using Data;
using Domain;
using Domain.service;
using HelpMeDeskNet5.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private IService _service;
        private IMapper _mapper;
        public TicketController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                var tickets = _service.GetAllTickets().OrderByDescending(x => x.Id);
                var model = new TicketListViewModel
                {
                    Tickets = tickets
                };

                return View(model);
                //return NotFound();
            }

            var viewModel = ConstructTicketViewModel(id);
            return View("Detail", viewModel);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            var viewModel = ConstructTicketViewModel(null);
            return View("Edit", viewModel);
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
            var viewModel = ConstructTicketViewModel(id);
            return View(viewModel);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TicketViewModel model)
        {
            var ticket = _mapper.Map<TicketDTO>(model);
            if (ModelState.IsValid)
            {
                if (ticket.Id == 0)
                    _service.AddTicket(ticket);
                else
                    _service.EditTicket(ticket);

                return RedirectToAction("Detail", new { id = ticket.Id });
            }

            model.TicketStatuses = _service.GetAllTicketStatuses();
            model.Projects = _service.GetAllProjects();
            model.Users = _service.GetAllUsers();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Comment(int id, string comment)
        {
            var ticket = _service.GetTicket(id);
            if (ticket == null)
                return NotFound();

            var newTicketComment = new TicketCommentDTO(id, DateTime.Now, comment);
            var addedTicketComment = _service.AddTicketComment(newTicketComment);
            if (addedTicketComment == null)
                return StatusCode(400);

            return View("Detail", ConstructTicketViewModel(id));
        }

        private TicketViewModel ConstructTicketViewModel(int? id)
        {
            var ticket = (id == null || id == 0) ? null : _service.GetTicket(id.Value);
            var model = ReferenceEquals(null, ticket) ? new TicketViewModel() :
                _mapper.Map<TicketViewModel>(ticket);
            model.TicketStatuses = _service.GetAllTicketStatuses();
            model.Projects = _service.GetAllProjects();
            model.Users = _service.GetAllUsers();
            model.User = _service.GetUser(User.Identity.Name);

            return model;
        }
    }
}
