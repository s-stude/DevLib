using System;
using System.Security.Principal;

namespace DevLib.Infrastructure.Web.Security
{
    [Serializable]
    public class CustomIdentity : MarshalByRefObject, IIdentity
    {
        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return string.IsNullOrWhiteSpace(Name) == false; }
        }

        public CustomIdentity(string name)
        {
            Name = name;
        }
    }
}