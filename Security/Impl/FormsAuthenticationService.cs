using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace DevLib.Infrastructure.Web.Security.Impl
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public void SignIn(FormsUser formsUser, bool createPersistentCookie)
        {
            var accountEntry = new AccountEntry(formsUser);

            var authTicket = new FormsAuthenticationTicket(1,
                                                           formsUser.Login,
                                                           DateTime.Now,
                                                           DateTime.Now.AddMinutes(45),
                                                           createPersistentCookie,
                                                           accountEntry.Serialize());

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName.ToUpper(), encryptedTicket)
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };

            HttpContext.Current.Response.Cookies.Add(authCookie);

            var identity = new CustomIdentity(authTicket.Name);

            HttpContext.Current.User = new GenericPrincipal(identity, Enumerable.Empty<string>().ToArray());
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}