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

        public int StudentRegister()
        {
            string firstName, lastName, userName, password, homeRoom, exit;
            int yearLevel;

            Console.WriteLine("Welcome to Student Register");
            Console.WriteLine("If you don't want to register and want to exit, please enter x");
            exit = Console.ReadLine().ToLower();
            if (exit.Equals("x"))
                return 2;
            Console.WriteLine("REGISTER HERE:");
            do
            {
                Console.WriteLine("Please enter your first name: ");
                firstName = Console.ReadLine();
                if(firstName.Length > 30)
                    Console.WriteLine("Invalid input. Please enter your first name again. It must be less than 30 characters.");
            } while (firstName.Length > 30);
            do
            {
                Console.WriteLine("Please enter your last name: ");
                lastName = Console.ReadLine();
                if (lastName.Length > 30)
                    Console.WriteLine("Invalid input. Please enter your last name again. It must be less than 30 characters.");
            } while (lastName.Length > 30);
            do
            {
                Console.WriteLine("Please enter your year level: ");
                yearLevel = int.Parse(Console.ReadLine());
                if (yearLevel < 9 || yearLevel > 13)
                    Console.WriteLine("Invalid input. Please enter your year level again. It must be between 9 to 13.");
            } while (yearLevel < 9 || yearLevel > 13);
            do
            {
                Console.WriteLine("Please enter your homeroom: ");
                homeRoom = Console.ReadLine();
                if (homeRoom.Length > 5)
                    Console.WriteLine("Invalid input. Please enter your homeroom again. It must be 5 characters long.");
            } while (homeRoom.Length > 5);
            do
            {
                Console.WriteLine("Please enter a username: ");
                userName = Console.ReadLine();
                if (userName.Length > 10 || userName.Length < 5)
                    Console.WriteLine("Invalid input. Please enter your username again. It must be between 5 to 10 characters.");
            } while (userName.Length > 10 || userName.Length < 5);
            do
            {
                Console.WriteLine("Please enter a password: ");
                password = Console.ReadLine();
                if (password.Length > 10 || password.Length < 5)
                    Console.WriteLine("Invalid input. Please enter your password again. It must be between 5 to 10 characters.");
            } while (password.Length > 10 || password.Length < 5);
            Console.WriteLine("Registration successful");
            int studentID = 0;
            Students student1 = new Students(studentID, lastName, firstName, yearLevel, homeRoom, userName, password);
            int generateId = storageManager.AddStudent(student1);
            Console.WriteLine($"New student inserted with ID: {generateId}");
            return 1;
        }


        public int TeacherMenu()
        {
            int choice;
            Console.WriteLine("Welcome to Teacher Menu! ");
            do
            {
                Console.WriteLine("1. Students ");
                Console.WriteLine("2. Groups");
                Console.WriteLine("3. Teachers");
                Console.WriteLine("4. Tasks");
                Console.WriteLine("5. Badges");
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

        public int Students()
        {
            int studentChoice;
            Console.WriteLine("Welcome to Students");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all students");
            Console.WriteLine("2. Update student's name");
            Console.WriteLine("3. Update student's year level");
            Console.WriteLine("4. Update student's homeroom");
            Console.WriteLine("5. Add a new student");
            Console.WriteLine("6. Delete a student");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            studentChoice = int.Parse(Console.ReadLine());  
            return studentChoice;
        }

        public int Groups()
        {
            int groupChoice;
            Console.WriteLine("Welcome to Groups");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all Groups");
            Console.WriteLine("2. Update a group's name");
            Console.WriteLine("3. Insert a new group");
            Console.WriteLine("4. Delete a group");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            groupChoice = int.Parse(Console.ReadLine());
            return groupChoice;
        }

        public int Teachers()
        {
            int teacherChoice;
            Console.WriteLine("Welcome to Teachers");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all Teachers");
            Console.WriteLine("2. Update a teacher's name");
            Console.WriteLine("3. Add a new teacher");
            Console.WriteLine("4. Delete a teacher");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            teacherChoice = int.Parse(Console.ReadLine());
            return teacherChoice;
        }

        public int Tasks()
        {
            int taskChoice;
            Console.WriteLine("Welcome to Tasks");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all Tasks");
            Console.WriteLine("2. Update a task's name");
            Console.WriteLine("3. Update a task's point value");
            Console.WriteLine("4. Add a new task");
            Console.WriteLine("5. Delete a task");
            Console.WriteLine("6. Assign a task to a student");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            taskChoice = int.Parse(Console.ReadLine());
            return taskChoice;
        }

        public int Badges()
        {
            int badgeChoice;
            Console.WriteLine("Welcome to Badges");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all Badges");
            Console.WriteLine("2. Update a badge name");
            Console.WriteLine("3. Update a badge level");
            Console.WriteLine("4. Add a new badge");
            Console.WriteLine("5. Delete a badge");
            Console.WriteLine("6. Award a badge to a student");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            badgeChoice = int.Parse(Console.ReadLine());
            return badgeChoice;
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
        public void DisplayGroups(List<Groups> groups)
        {
            foreach (Groups group in groups)
            {
                Console.WriteLine($"{group.GroupID}, {group.GroupName}");
            }
        }

        public void DisplayStudents(List<Students> students)
        {
            foreach (Students student in students)
            {
                Console.WriteLine($"{student.StudentID}, {student.LastName}, {student.FirstName}, {student.YearLevel}, {student.HomeRoom}");
            }
        }

        public void DisplayTeachers(List<Teachers> teachers)
        {
            foreach (Teachers teacher in teachers)
            {
                Console.WriteLine($"{teacher.TeacherID}, {teacher.LastName}, {teacher.FirstName}");
            }
        }

        public void DisplayTasks(List<Tasks> tasks)
        {
            foreach (Tasks task in tasks)
            {
                Console.WriteLine($"{task.TaskID}, {task.TaskName}, {task.PointsValue}");
            }
        }

        public void DisplayBadges(List<Badges> badges)
        {
            foreach (Badges badge in badges)
            {
                Console.WriteLine($"{badge.BadgeID}, {badge.BadgeName}, {badge.BadgeLevel}");
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
