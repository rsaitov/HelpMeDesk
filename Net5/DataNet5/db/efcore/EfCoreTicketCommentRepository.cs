using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfCoreTicketCommentRepository : EfCoreRepository<TicketCommentDTO, HelpMeDeskContext>
    {
        public EfCoreTicketCommentRepository(HelpMeDeskContext context) : base(context)
        {

        }
    }
}
