 using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Azure.Identity;
using Microsoft.VisualBasic;
using SchoolGroupsApp.Model;
using SchoolGroupsApp.Repositories;

namespace SchoolGroupsApp.View   
{
    public class ConsoleView
    {
        private static StorageManager storageManager;

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

        public int CheckTeacherLogin(string userName, string password)
        {
            List<Teachers> teachers = storageManager.GetAllTeachers();

            foreach (Teachers teacher in teachers)
            {
                if (userName.Equals(teacher.UserName) && password.Equals(teacher.Password))
                {
                    Console.WriteLine("Login successful!");
                    return 1;
                }
            }
            Console.WriteLine("Your username or password is incorrect. Please enter them again.");
            return 0;
        }
        public int TeacherLogin()
        {
            string userName;
            string password;
            Console.Clear();
            Console.WriteLine("Welcome to Teacher Login ");
            do
            {
                Console.WriteLine("LOGIN HERE:");
                Console.WriteLine("Please enter your username: ");
                userName = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
                Console.WriteLine("Press 2 to Return to Main Menu");
                int x = int.Parse(Console.ReadLine());
                if (x == 2)
                    return x;
                if (userName.Length > 10 || userName.Length < 5)
                    Console.WriteLine("Invalid input. Please enter your username again. It must be between 5 to 10 characters.");
                if (password.Length > 10 || password.Length < 5)
                    Console.WriteLine("Invalid input. Please enter your password again. It must be between 5 to 10 characters.");
            } while ((userName.Length > 10) || (userName.Length < 5) || (password.Length > 10) || (password.Length < 5));
           int r  = CheckTeacherLogin(userName, password);
            if (r == 0)
                TeacherLogin();
            return r;
           
        }

        public int CheckStudentLogin(string userName, string password)
        {
            List<Students> students = storageManager.GetAllStudents();

            foreach (Students student in students)
            {
                if (userName.Equals(student.UserName) && password.Equals(student.Password))
                {
                    Console.WriteLine("Login successful!");
                    return 1;
                }
            }
            Console.WriteLine("Your username or password is incorrect. Please enter them again.");
            return 0;
        }
        public int StudentLogin()
        {
            string userName;
            string password;
            Console.Clear();
            Console.WriteLine("Welcome to Student Login ");
            do
            {
                Console.WriteLine("LOGIN HERE:");
                Console.WriteLine("Please enter your username: ");
                userName = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
                Console.WriteLine("Press 2 to Return to Main Menu");
                int x = int.Parse(Console.ReadLine());
                if (x == 2)
                    return x;
                if (userName.Length > 10 || userName.Length < 5)
                    Console.WriteLine("Invalid input. Please enter your username again. It must be between 5 to 10 characters.");
                if (password.Length > 10 || password.Length < 5)
                    Console.WriteLine("Invalid input. Please enter your password again. It must be between 5 to 10 characters.");
            } while ((userName.Length > 10) || (userName.Length < 5) || (password.Length > 10) || (password.Length < 5));
            int r = CheckStudentLogin(userName, password);
            if (r == 0)
                StudentLogin();
            return r;
        }

        public void StudentRegister()
        {
            Console.WriteLine("Welcome to Student Register");
            Console.WriteLine("REGISTER HERE:");
            Console.WriteLine("Please enter your first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Please enter your year level: ");
            year = Console.ReadLine();
            Console.WriteLine("Please enter your homeroom: ");
            homeroom = Console.ReadLine();
            Console.WriteLine("Please enter a username: ");
            userName = Console.ReadLine();
            Console.WriteLine("Please enter a password: ");
            Console.WriteLine("Press 2 to return to Main Menu");
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
