using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Persistence.Users.Queries
{
    public class UserPaginationDto
    {
        public int id {  get; set; }
        public string name { get; set; } = string.Empty;
        public string mail { get; set; } = string.Empty;
        public bool asset { get; set; }
        public int state { get; set; }
        public int TotalRows { get; set; }
    }
}