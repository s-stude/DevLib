using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DevLib.Infrastructure.Web.Security
{
    [Serializable]
    public class AccountEntry
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public AccountEntry()
        {
            
        }

        public AccountEntry(FormsUser formsUser)
        {
            Id = formsUser.Id;
            Login = formsUser.Login;
        }

        public string Serialize()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof(AccountEntry));
                formatter.Serialize(stream, this);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}