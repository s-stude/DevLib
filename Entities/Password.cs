using System;
using System.Linq;
using System.Security.Cryptography;

namespace DevLib.Security.Entities
{
    public class Password
    {
        const int SaltSize = 20; // derive a 20-byte key

        [Obsolete]
        public Password()
        {
        }

        public Password(string password)
            : this()
        {
            ProcessInputPassword(password);
        }

        public virtual byte[] PasswordKey { get; protected set; }
        public virtual byte[] PasswordSalt { get; protected set; }

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