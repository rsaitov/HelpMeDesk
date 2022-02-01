using Data;
using Domain;
using Domain.service;
using HelpMeDeskNet5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.Controllers
{
    public class TicketController : Controller
    {
        private IRepository _repository;
        private IService _service;
        public TicketController()
        {
            _repository = new MockRepository();
            _service = new Service(_repository);
        }
        public IActionResult Index()
        {
            var tickets = _service.GetAllTickets();
            var model = new TicketListViewModel {
                Tickets = tickets
            };

            return View(model);
        }

        [Route("ticket/{id}")]
        public IActionResult Ticket(int id)
        {
            var firstTicket = _service.GetAllTickets().FirstOrDefault(x => x.Id == id);
            var model = new TicketViewModel
            {
                Ticket = firstTicket
            };

            return View(model);
        }
    }
}
