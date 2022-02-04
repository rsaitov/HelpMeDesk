using Data;
using Domain;
using Domain.service;
using HelpMeDeskNet5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HelpMeDeskNet5.Controllers
{
    public class TicketController : Controller
    {
        private IService _service;
        public TicketController(IService service)
        {
            _service = service;
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

            var firstTicket = _service.GetAllTickets().FirstOrDefault(x => x.Id == id);
            var model = new TicketViewModel
            {
                Ticket = firstTicket
            };

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
                //_db.Category.Add(obj);
                //_db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return View(new TicketDTO());

            var firstTicket = _service.GetAllTickets().FirstOrDefault(x => x.Id == id);
            return View(firstTicket);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                //_db.Category.Update(obj);
                //_db.SaveChanges();
                //return RedirectToAction("Index");

                if (ticket.Id == 0)
                    _service.AddTicket();
                else
                    _service.EditTicket(ticket);
            }
            return View(ticket);
        }
    }
}
