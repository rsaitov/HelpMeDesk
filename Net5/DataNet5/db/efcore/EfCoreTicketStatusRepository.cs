﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfCoreTicketStatusRepository : EfCoreRepository<TicketStatusDTO, HelpMeDeskContext>
    {
        public EfCoreTicketStatusRepository(HelpMeDeskContext context) : base(context)
        {

        }
    }
}
