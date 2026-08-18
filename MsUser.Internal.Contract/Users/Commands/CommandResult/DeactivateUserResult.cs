using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Internal.Contract.Users.Commands.CommandResult
{
    public record DeactivateUserResult(bool Success, int Id);
}