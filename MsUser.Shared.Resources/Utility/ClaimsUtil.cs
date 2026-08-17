using RealPlaza.Web.Web.Middleware.TokenHandling;
using System;

namespace MsCustomer.Shared.Resources.Utility
{
    public class ClaimsUtil
    {
        private const int DEFAULT_USER_ID = 0;

        private const string DEFAULT_USER_NAME = "";
        private const string USER_ID_CLAIM_TYPE = "codigo_unico";

        public static int GetUserId()
        {
            try
            {
                var claimValue = ClaimsMiddleware.GetCurrentClaimsPrincipal()?.FindFirst(USER_ID_CLAIM_TYPE)?.Value;

                if (int.TryParse(claimValue, out var result))
                {
                    return result;
                }
                else
                {
                    return DEFAULT_USER_ID;
                }
            }
            catch (Exception)
            {
                return DEFAULT_USER_ID;
            }
        }

        public static string GetUserName()
        {
            try
            {
                return ClaimsMiddleware.GetUser() ?? DEFAULT_USER_NAME;
            }
            catch (Exception)
            {
                return DEFAULT_USER_NAME;
            }
        }
    }
}
