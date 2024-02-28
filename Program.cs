using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OwenBartleChallengeM7
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerList customerList = new CustomerList();
            customerList.Changed += DisplayCustomerList;

            bool quit = false;
            while(!quit)
            {
                Console.WriteLine("Choose an option (1-3)");
                Console.WriteLine("\t1. Add a new customer\n\t2. Remove an existing customer\n\t3. Quit program");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        addCustomer(customerList);
                        break;
                    case "2":
                        removeCustomer(customerList);
                        break;
                    case "3":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Enter an option 1-3");
                        break;
                }
            }

        }

        static void addCustomer(CustomerList customerList)
        {
            const int MAX_CHARACTERS = 16;
            bool quit = false;

            while (!quit)
            {
                string firstName = "";
                string lastName = "";
                string email = "";
                string id = "";

                while (firstName.Length == 0)
                {
                    Console.WriteLine("\nFirst Name: (16 characters max)");
                    firstName = Console.ReadLine();

                    if (firstName.Length >= MAX_CHARACTERS)
                    {
                        Console.WriteLine("First name input exceeds the maximum length of characters (16). Try again");
                        firstName = "";
                    }
                }

                while (lastName.Length == 0)
                {
                    Console.WriteLine("\nLast Name: (16 characters max)");
                    lastName = Console.ReadLine();
                    if (lastName.Length >= MAX_CHARACTERS)
                    {
                        Console.WriteLine("Last name input exceeds the maximum length of characters (16). Try again");
                        lastName = "";
                    }
                }

                while (email.Length == 0)
                {
                    Console.WriteLine("\nEmail Address: ex: ******@gmail.com");
                    email = Console.ReadLine();
                    if (!email.Contains('@'))
                    {
                        Console.WriteLine("Invalid email address. Try again.");
                        email = "";
                    }
                }

                while (id.Length == 0)
                {
                    Console.WriteLine("\nPhone Number: (***-***-****)");
                    id = Console.ReadLine();
                    if (!Regex.IsMatch(id, @"\d{3}-\d{3}-\d{4}$"))
                    {
                        Console.WriteLine("Invalid phone number. Try again");
                        id = "";
                    }
                }

                Customer newCustomer = new Customer(firstName, lastName, email, id);
                customerList.Add(newCustomer);

                Console.WriteLine("Customer profile added successfully.\nAdd another? (y/n)");
                string choice = Console.ReadLine().ToUpper();

                if (choice != "Y")
                {
                    quit = true;
                }
                else
                {
                    firstName = "";
                    lastName = "";
                    email = "";
                    id = "";
                }
            }
        }

        static void removeCustomer(CustomerList customerList)
        {
            bool quit = false;
            while (!quit)
            {
                if (customerList.count == 0)
                {
                    Console.WriteLine("No customers to remove.");
                    return;
                }

                for (int i = 0; i < customerList.count; i++)
                {
                    Console.WriteLine(customerList[i].getDisplayText(i));
                }

                Console.WriteLine("Enter customer number to remove: ");
                int index;

                if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= customerList.count)
                {
                    Customer delCustomer = customerList[index - 1];
                    customerList.Remove(delCustomer);
                    Console.WriteLine("Customer profile successfully removed.");
                }
                else
                {
                    Console.WriteLine("Invalid customer number. ");
                }
            }
        }

        static void DisplayCustomerList(CustomerList customerList)
        {
            Console.WriteLine("\nCustomer List: ");
            for (int i = 0; i < customerList.count; i++)
            {
                Console.WriteLine(customerList[i].getDisplayText(i));
            }
        }
    }
}
