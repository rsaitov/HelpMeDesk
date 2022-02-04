using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EfCoreUserRepository : EfCoreRepository<UserDTO, HelpMeDeskContext>
    {
        public EfCoreUserRepository(HelpMeDeskContext context) : base(context)
        {

        }
    }
}
