using EntityFrameworkCore.EncryptColumn.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.EncryptColumn.Example.Entity
{
    public class User
    {
        public Guid ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [EncryptColumn]
        public string EmailAddress { get; set; }
        [EncryptColumn]
        public string IdentityNumber { get; set; }
    }
}
