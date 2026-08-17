using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsUser.Domain.Core
{
    [ExcludeFromCodeCoverage]
    public abstract class Entity
    {
        public int CreateId { get; set; }
        public string CreateUser { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public int UpdateId { get; set; }
        public string UpdateUser { get; set; } = string.Empty;
        public int State { get; set; }
    }
}