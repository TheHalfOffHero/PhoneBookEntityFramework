using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string Name, string PhoneNumber) { 
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
