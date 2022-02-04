using Data;
using Domain;
using Domain.service;
using HelpMeDeskNet5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeDeskNet5.Controllers
{
    public class TicketController : Controller
    {
        private EfCoreTicketRepository _ticketRepository;
        public TicketController(EfCoreTicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketRepository.GetAll();
            var model = new TicketListViewModel
            {
                Tickets = tickets
            };

            return View(model);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();

            var firstTicket = await _ticketRepository.Get(id.Value);
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
        public async Task<IActionResult> Create(Ticket obj)
        {
            if (ModelState.IsValid)
            {
                await _ticketRepository.Add(obj);
                return RedirectToAction("Detail");
            }
            return View(obj);
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
                return View(new TicketDTO());

            var firstTicket = await _ticketRepository.Get(id.Value);
            return View();
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                await _ticketRepository.Update(ticket);
                return RedirectToAction("Detail");
            }
            return View(ticket);
        }
    }
}
