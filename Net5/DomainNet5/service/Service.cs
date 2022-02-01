using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.service
{
    public class Service : IService
    {
        private IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<TicketDTO> GetAllTickets()
        {
            return _repository.SelectTickets();
        }
    }
}
