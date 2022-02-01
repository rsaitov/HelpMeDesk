using Domain;
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
        public IActionResult Index()
        {
            var model = new TicketListViewModel {
                Tickets = new List<Ticket> {
                    new Ticket {Name = "Test"},
                    new Ticket {Name = "Second"},
                    new Ticket {Name = "Third"},
                }
            };

            return View(model);
        }
    }
}
