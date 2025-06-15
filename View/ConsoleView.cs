 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using SchoolGroupsApp.Model;

namespace SchoolGroupsApp.View   
{
    public class ConsoleView
    {
        public int LoginMenu()
        {
            Console.WriteLine("Welcome to our School Groups Programme ")
            Console.WriteLine("LOGIN HERE:");
            Console.WriteLine("1. Teacher Login");
            Console.WriteLine("2. Student Login");
            Console.WriteLine("3. Student Registration");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Select an option: ");
            int choice = int.Parse(Console.ReadLine());
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
