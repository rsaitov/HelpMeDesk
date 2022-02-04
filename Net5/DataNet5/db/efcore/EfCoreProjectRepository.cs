using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfCoreProjectRepository : EfCoreRepository<ProjectDTO, HelpMeDeskContext>
    {
        public EfCoreProjectRepository(HelpMeDeskContext context) : base(context)
        {

        }
    }
}
