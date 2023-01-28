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

            //context.Contacts.Add(Matt);

            //context.Add(Matt);

            var flag = "c";

            while(flag != "q")
            {
                Console.WriteLine("");
                Console.WriteLine(@"Welcome to the Phoebook application!
 - Enter c to create a new contact
 - Enter r to search for a contact
 - Enter u to update a contact
 - Enter d to delete a contact
 - Enter q to quit the application");

                flag = Console.ReadLine();
                Console.WriteLine();

                switch (flag)
                {
                    //Creating a new contact and adding it to context
                    case "c":

                        //string newContactName = "";
                        //string newContactNumber = "";

                        Console.Write("Enter the name of the new contact:");
                        string newContactName = Console.ReadLine();

                        Console.Write("Enter the number of the new contact:");
                        string newContactNumber = Console.ReadLine();

                        try
                        {
                            Contact newContact = new Contact(newContactName, newContactNumber);
                            context.Add(newContact);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Either newContactName or newContactNumber is empty");
                            throw;
                        }

                        break;

                    //Reading a select contact from the list
                    case "r":
                        Console.Write("Enter the Name of the Contact you would like the number for: ");
                        string contactName = Console.ReadLine();
                        foreach (var contact in context.Contacts)
                        {
                            if (contactName == contact.Name)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("The PhoneNumber for {0} is: {1}", contact.Name, contact.PhoneNumber);
                            }
                        }
                        break;

                    case "u":
                        Console.Write("Enter the Name of the contact you want to update: ");
                        string temp = Console.ReadLine();
                        Console.WriteLine();

                        foreach (var contact in context.Contacts)
                        {
                            if (temp == contact.Name)
                            {
                                Console.Write("Enter the new phone number for this contact:");
                                contact.PhoneNumber = Console.ReadLine();
                                Console.WriteLine("Updated the contact {0} phone number to {1}", contact.Name, contact.PhoneNumber);
                            }
                        }

                        break;

                    case "d":
                        Console.Write("Enter the name of the contact you want to delete: ");
                        string deleteContact = Console.ReadLine();

                        foreach (var contact in context.Contacts)
                        {
                            if (contact.Name == deleteContact)
                            {
                                context.Contacts.Remove(contact);
                                Console.WriteLine("Deleted all contact informatin for {0}", deleteContact);
                            }
                        }

                        break;

                    case "q":
                        Console.WriteLine("Thank you for using my Entity Framework PhoneBook!");
                        break;

                    default:
                        Console.WriteLine("The option you entered does not match, please try again");
                        break;
                }
                context.SaveChanges();
            }

            
        }
    }
}