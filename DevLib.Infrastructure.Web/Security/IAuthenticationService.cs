namespace DevLib.Infrastructure.Web.Security
{
    public interface IAuthenticationService
    {
        void SignIn(FormsUser formsUser, bool createPersistentCookie);
        void SignOut();
    }
}