using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a new Context object in order to interact with the database
            using PhoneBookContext context = new PhoneBookContext();

            //Creating a new contact Object
            Contact Matt = new Contact()
            {
                Name = "Matt",
                PhoneNumber = "123-456-7890"
            };

            context.Contacts.Add(Matt);

            context.SaveChanges();
        }
    }
}