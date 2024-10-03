using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Account
    {
        public string Name { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public IEnumerable<Incident> Incidents { get; set; }
    }
}
