using System;
using DevLib.Domain;
using DevLib.Security.Enums;

namespace DevLib.Security.Entities
{
    public class SocialNetworkAccount : IEntity
    {
        public virtual int Id { get; protected set; }
        
        public virtual SocialAuthProvider Provider { get; protected set; }
        public virtual string ProviderUserId { get; protected set; }
        public virtual User User { get; protected set; }
        
        protected SocialNetworkAccount()
        {
        }

        public SocialNetworkAccount(SocialAuthProvider provider, User user, string providerUserId)
            : this()
        {
            if (user == null) throw new ArgumentNullException("user");
            if (providerUserId == null) throw new ArgumentNullException("providerUserId");

            Provider = provider;
            User = user;
            ProviderUserId = providerUserId;
        }
    }
}