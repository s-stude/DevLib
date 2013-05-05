using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace DevLib.Infrastructure.Web.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] _roles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (httpContext.User == null)
                return false;

            if (_roles.Any())
            {
                // TODO: Do we need roles in this app?
//                var queryBuilder = DependencyResolver.Current.GetService<IQueryBuilder>();
//                var logger = DependencyResolver.Current.GetService<ILoggingService>();
//
//                try
//                {
//                    var userRolesVM = queryBuilder.For<UserRolesVM>().WithEmptyCriterion();
//                    return _roles.Any(r => userRolesVM.Groups.Any(g => g.GroupId == r));
//                }
//                catch (Exception exc)
//                {
//                    logger.Log(exc);
//                    return false;
//                }
            }

            return httpContext.Request.IsAuthenticated;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;

            if (filterContext.IsChildAction)
                return;

            if (!context.Request.IsAuthenticated)
            {
                string loginUrl = FormsAuthentication.LoginUrl;
                string path = HttpUtility.UrlEncode(context.Request.Url.PathAndQuery);

                string url = String.Format("{0}?ReturnUrl={1}", loginUrl, path);

                filterContext.Result = new RedirectResult(url);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                                                                     new
                                                                         {
                                                                             controller = "Error",
                                                                             action = "AccessDenided"
                                                                         }));
            }
        }
    }
}