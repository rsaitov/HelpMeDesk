using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfCoreTicketRepository : EfCoreRepository<TicketDTO, HelpMeDeskContext>
    {
        public EfCoreTicketRepository(HelpMeDeskContext context) : base(context)
        {

        }
    }
}
