using System;
using System.Linq;
using System.Security.Cryptography;
using DevLib.Domain;

namespace DevLib.Security.Entities
{
    public class Password : IEntity
    {
        public virtual Guid Id { get; protected set; }
        public virtual byte[] PasswordKey { get; protected set; }
        public virtual byte[] PasswordSalt { get; protected set; }
        public virtual User User { get; protected set; }

        const int SaltSize = 20; // derive a 20-byte key

        [Obsolete]
        protected Password()
        {
        }

        public Password(User user, string password)
            : this()
        {
            if (user == null) throw new ArgumentNullException("user");
            User = user;

            ProcessInputPassword(password);
        }

        private void ProcessInputPassword(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize))
            {
                PasswordSalt = deriveBytes.Salt;
                PasswordKey = deriveBytes.GetBytes(SaltSize);
            }
        }

        public virtual bool Verify(string passwordToVerify)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(passwordToVerify, PasswordSalt))
            {
                byte[] newKey = deriveBytes.GetBytes(SaltSize);

                if (!newKey.SequenceEqual(PasswordKey))
                    return false;

                return true;
            }
        }
    }
}