using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Internal.Contract.Users.Commands
{
    public record DeactivateUserCommand(int id);
}