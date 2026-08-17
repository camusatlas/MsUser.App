using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Internal.Contract.Users.Queries
{
    public record GetUserBySearch(int id, string name, string mail, bool asset, int state);
}