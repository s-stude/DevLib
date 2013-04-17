using System;
using DevLib.Domain;

namespace DevLib.Security.Entities
{
    public class User : IEntity
    {
        public virtual int Id { get; protected set; }
        public virtual string Login { get; protected set; }
        public virtual Password Password { get; protected set; }

        protected User()
        {

        }

        public User(string login)
            : this()
        {
            if (login == null) throw new ArgumentNullException("login");

            Login = login;
        }

        public virtual void SetPassword(string newPassword)
        {
            Password = new Password(this, newPassword);
        }

        public virtual bool VerifyPassword(string passwordToVerify)
        {
            return Password.Verify(passwordToVerify);
        }
    }
}