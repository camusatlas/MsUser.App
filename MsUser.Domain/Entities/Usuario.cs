using MsUser.Domain.Core;
using System;

namespace MsUser.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Asset { get; set; }
        public int state { get; set; }
        public int CreateId { get; set; }
        public string CreateUser { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public int UpdateId { get; set; }
        public string UpdateUser { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public Usuario() { }
        public Usuario(int id, string name, string mail, string password, DateTime createdate, bool asset, int state, int createid, string createuser, int updateid, string updateuser, DateTime updatedate, DateTime? verifieddate)
        {
            Id = id;
            Name = name;
            Mail = mail;
            Password = password;
            CreateDate = createdate;
            Asset = asset;
            State = state;
            CreateId = createid;
            CreateUser = createuser;
            CreateDate = createdate;
            UpdateId = updateid;
            UpdateUser = updateuser;
            UpdateDate = updatedate;
            VerifiedDate = verifieddate;
        }
        public Usuario(string name, string mail, string password, DateTime createdate, bool asset, int state, int createid, string createuser, int updateid, string updateuser, DateTime updatedate, DateTime? verifieddate)
        {
            Name = name;
            Mail = mail;
            Password = password;
            CreateDate = createdate;
            Asset = asset;
            State = state;
            CreateId = createid;
            CreateUser = createuser;
            UpdateId = updateid;
            UpdateUser = updateuser;
            UpdateDate = updatedate;
            VerifiedDate = verifieddate;
        }
        public Usuario(string name, string mail, string password, DateTime createdate, bool asset, int state, int createid, string createuser, DateTime? verifieddate)
        {
            Name = name;
            Mail = mail;
            Password = password;
            CreateDate = createdate;
            Asset = asset;
            State = state;
            CreateId = createid;
            CreateUser = createuser;
        }
    }
}
