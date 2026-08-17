using MsCustomer.Shared.Resources.Utility;
using RealPlaza.Core.Common.Service.Interfaces;
using System;

namespace MsUser.Shared.Resources.Utility
{
    public class AuditUtil
    {
        private readonly IDateService _dateService;
        public AuditUtil(IDateService dateService)
        {
            _dateService = dateService;
        }

        public (int UserId, string UserName, DateTime DateUtc) GetAuditInfo()
        {
            return (
                ClaimsUtil.GetUserId(),
                ClaimsUtil.GetUserName(),
                DateTime.SpecifyKind(_dateService.GetDate(), DateTimeKind.Utc)
            );
        }
    }
}
