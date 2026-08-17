using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Internal.Contract.User.Commands.CommandResult
{
    public record CreateUserResult
    (
        bool Success,
        int id
    );
}
