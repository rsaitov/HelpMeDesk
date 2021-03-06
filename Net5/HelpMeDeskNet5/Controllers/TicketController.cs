using AutoMapper;
using Data;
using Domain;
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
    public class TicketController : Controller
    {
        private IService _service;
        private IMapper _mapper;
        public TicketController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [Route("")]
        [Route("Ticket")]
        public IActionResult Index()
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null)
                return StatusCode(401);

            var tickets = _service.GetAllTickets().OrderByDescending(x => x.Id);
            List<TicketDTO> filteredTickets = null;

            if (currentUser.Role == UserRole.User)
                filteredTickets = tickets.Where(x => x.AuthorId == currentUser.Id).ToList();
            if (currentUser.Role == UserRole.Executor)
                filteredTickets = tickets.Where(x => x.ProjectId == currentUser.ProjectId).ToList();

            var model = new TicketListViewModel
            {
                Tickets = filteredTickets ?? tickets.ToList()
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var viewModel = ConstructTicketViewModel(id);
            return View(viewModel);
        }

        //GET - EDIT
        //[Route("Ticket/Edit")]
        public IActionResult Edit(int? id)
        {
            var viewModel = ConstructTicketViewModel(id);
            return View(viewModel);
        }

        //POST - EDIT
        //[Route("Ticket/Edit")]
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

                return RedirectToAction("Index", new { id = ticket.Id });
            }

            model.TicketStatuses = _service.GetAllTicketStatuses();
            model.Projects = _service.GetAllProjects();
            model.Users = _service.GetAllUsers();
            model.User = _service.GetUser(User.Identity.Name);
            return View(model);
        }
        private bool GetCommentAccess(TicketDTO ticket, string email) => _service.HaveAccessToComment(ticket, email);

        private UserDTO GetCurrentUser()
        {
            var email = HttpContext.User.Identity.Name;
            return _service.GetUser(email);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Comment(int id, string comment)
        {
            var ticket = _service.GetTicket(id);
            if (ticket == null)
                return NotFound();

            var user = GetCurrentUser();
            if (user == null)
                return StatusCode(401);

            var newTicketComment = new TicketCommentDTO(id, DateTime.Now, comment, user.Id);
            newTicketComment.ticket = ticket;
            var addedTicketComment = _service.AddTicketComment(newTicketComment, user.Email);
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
            model.CommentAccess = GetCommentAccess(ticket, HttpContext.User.Identity.Name);

            return model;
        }
    }
}
