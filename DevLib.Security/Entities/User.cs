using System;
using System.Collections.Generic;
using System.Linq;
using DevLib.Domain;
using DevLib.Security.Enums;

namespace DevLib.Security.Entities
{
    public class User : IEntity
    {
        private readonly ICollection<SocialNetworkAccount> _socialNetworkAccounts;

        public virtual int Id { get; protected set; }
        public virtual string Login { get; protected set; }
        public virtual Password Password { get; protected set; }
        public virtual string DisplayName { get; protected set; }
        public virtual string Email { get; set; }


        public virtual ICollection<SocialNetworkAccount> SocialNetworkAccounts
        {
            get { return _socialNetworkAccounts; }
        }
        
        protected User()
        {
            _socialNetworkAccounts = new List<SocialNetworkAccount>();
        }

        public User(string login)
            : this()
        {
            if (login == null) throw new ArgumentNullException("login");

            Login = login;
        }

        public virtual void SetPassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword) == false)
            {
                Password = new Password(this, newPassword);
            }
        }

        public virtual bool VerifyPassword(string passwordToVerify)
        {
            return Password.Verify(passwordToVerify);
        }

        public virtual void AddSocialNetworkAccount(SocialAuthProvider provider, string providerUserId)
        {
            if (_socialNetworkAccounts.All(x => x.Provider != provider))
            {
                var socialNetworkAccount = new SocialNetworkAccount(provider, this, providerUserId);

                _socialNetworkAccounts.Add(socialNetworkAccount);
            }
        }

        public virtual void ChangeDisplayName(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName) == false)
            {
                DisplayName = displayName;
            }
        }

        public virtual void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) == false)
            {
                Email = email;
            }
        }
    }
}