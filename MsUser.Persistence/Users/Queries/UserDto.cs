using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Persistence.Users.Queries
{
    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string mail { get; set; } = string.Empty;
        public bool asset { get; set; }
        public int state { get; set; }
    }

    public class UsertrictExistsRequest
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string mail { get; set; } = string.Empty;
        public bool asset { get; set; }
        public int state { get; set; }
    }

    public class UserExistsForUpdateRequest
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string mail { get; set; } = string.Empty;
        public bool asset { get; set; }
        public int state { get; set; }
    }
}