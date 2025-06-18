 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using SchoolGroupsApp.Model;

namespace SchoolGroupsApp.View   
{
    public class ConsoleView
    {
        public int LoginMenu()
        {
            int choice;
            Console.WriteLine("Welcome to our School Groups Programme ");
            do
            {
                Console.WriteLine("LOGIN HERE:");
                Console.WriteLine("1. Teacher Login");
                Console.WriteLine("2. Student Login");
                Console.WriteLine("3. Student Registration");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Select an option: ");
                choice = int.Parse(Console.ReadLine());
                if ((choice < 1) || (choice > 4))
                    Console.WriteLine("Invalid input. Please enter your choice again.");
            } while ((choice < 1) || (choice > 4));
            return choice;
        }

        public string TeacherLogin()
        {
            string userName;
            string password;
            Console.WriteLine("Welcome to Teacher Login ");
            do
            {
                Console.WriteLine("LOGIN HERE:");
                Console.WriteLine("Please enter your username: ");
                userName = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
                Console.WriteLine("Press r to Return to main menu");
                if (userName.Equals r)
                        LoginMenu();
                if ((choice < 1) || (choice > 4))
                    Console.WriteLine("Invalid input. Please enter your choice again.");
            } while ((choice < 1) || (choice > 4));
            return choice;
        }

        public int TeacherMenu()
        {
            int choice;
            Console.WriteLine("Welcome to Teacher Menu! ");
            do
            {
                Console.WriteLine("1. Students ");
                Console.WriteLine("2. Groups");
                Console.WriteLine("3. Badges");
                Console.WriteLine("4. Tasks");
                Console.WriteLine("5. Teachers");
                Console.WriteLine("6. Points");
                Console.WriteLine("7. Reports");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Select an option: ");
                choice = int.Parse(Console.ReadLine());
                if ((choice < 1) || (choice > 8))
                    Console.WriteLine("Invalid input. Please enter your choice again.");
            } while ((choice < 1) || (choice > 8));
            return choice;
        }

        public int StudentMenu()
        {
            int choice;
            Console.WriteLine("Welcome to Student Menu! ");
            do
            {
                Console.WriteLine("1. Join a group.");
                Console.WriteLine("2. Withdraw from a group.");
                Console.WriteLine("3. Badges");
                Console.WriteLine("4. Tasks");
                Console.WriteLine("5. Groups");
                Console.WriteLine("6. Points");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Select an option: ");
                choice = int.Parse(Console.ReadLine());
                if ((choice < 1) || (choice > 7))
                    Console.WriteLine("Invalid input. Please enter your choice again.");
            } while ((choice < 1) || (choice > 7));
            return choice;
        }
        public string DisplayMenu()
        {
            Console.WriteLine("Welcome to our School Groups Programme ");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Groups");
            Console.WriteLine("2. Update a group's name by groupID");
            Console.WriteLine("3. Insert a new group");
            Console.WriteLine("4. Delete a group by group_name");
            Console.Write("Select an option: ");
            return Console.ReadLine();
        }
        public void DisplayGroups(List<Groups> groups)
        {
            foreach (Groups group in groups)
            {
                Console.WriteLine($"{group.GroupID}, {group.GroupName}");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public string GetInput()
        {
            return Console.ReadLine();
        }
        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
