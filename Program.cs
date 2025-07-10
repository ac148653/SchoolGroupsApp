using System.Threading.Tasks.Dataflow;
using System.Transactions;
using Azure.Core;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SchoolGroupsApp.Model;
using SchoolGroupsApp.Repositories;
using SchoolGroupsApp.View;

namespace SchoolGroupsApp
{
    public class Program
    {
        private static StorageManager storageManager;
        private static ConsoleView view;

        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=SchoolGroupsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storageManager = new StorageManager(connectionString);
            int loginChoice, r = 0;
            do
            {
                loginChoice = view.LoginMenu();
                switch (loginChoice)
                {
                    case 1:
                        {
                            r = view.TeacherLogin();
                            if (r == 1)
                                TeacherMenuChoice();
                            if (r == 2)
                                break;
                        }
                        break;
                    case 2:
                        {
                            r = view.StudentLogin();
                            if (r == 1)
                                StudentMenuChoice();
                            if (r == 2)
                                break;
                        }
                        break;
                    case 3:
                        {
                            r = view.StudentRegister();
                            if (r == 1)
                                StudentMenuChoice();
                            if (r == 2)
                                break;
                        }
                        break;
                    case 4:
                        {
                            return;
                        }
                }

            } while (r == 2);
        }

        private static void TeacherMenuChoice()
        {
            int studentsChoice;
            int groupsChoice;
            do
            {
                int teacherChoice = view.TeacherMenu();
                switch (teacherChoice)
                {
                    case 1:
                        {
                            studentsChoice = view.Students();
                            if (studentsChoice >= 1 && studentsChoice <= 6)
                                StudentsChoice(studentsChoice);
                            if (studentsChoice == 7)
                                break;
                        }
                        break;
                    case 2:
                        {
                            groupsChoice = view.Groups();
                            if (groupsChoice >= 1 && groupsChoice <= 4)
                                GroupsChoice(groupsChoice);
                            if (groupsChoice == 5)
                                break;
                        }
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
                    case 7:
                    case 8:
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (studentsChoice == 7 || groupsChoice == 5);
        }
      
        

        public static void StudentsChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    {
                        List<Students> students = storageManager.GetAllStudents();
                        view.DisplayStudents(students);
                    }
                    break;
                case 2:
                    UpdateStudentName();
                    break;
                case 3:
                    UpdateStudentYear();
                    break;
                case 4:
                    UpdateStudentHomeroom();
                    break;
                case 5:
                    AddStudent();
                    break;
                case 6:
                    DeleteStudentByName();
                    break;
            }
        }

        private static void UpdateStudentName()
        {
            view.DisplayMessage("Enter the student Id to update: ");
            int studentId = view.GetIntInput();
            view.DisplayMessage("Enter the new last name: ");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the new first name: ");
            string firstName = view.GetInput();
            int rowsAffected = storageManager.UpdateStudentName(studentId, lastName, firstName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void UpdateStudentYear()
        {
            view.DisplayMessage("Enter the student ID to update: ");
            int studentId = view.GetIntInput();
            view.DisplayMessage("Enter the new year level: ");
            int yearLevel = view.GetIntInput();
            int rowsAffected = storageManager.UpdateStudentYear(studentId, yearLevel);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void UpdateStudentHomeroom()
        {
            view.DisplayMessage("Enter the student ID to update: ");
            int studentId = view.GetIntInput();
            view.DisplayMessage("Enter the new homeroom: ");
            string homeRoom = view.GetInput();
            int rowsAffected = storageManager.UpdateStudentHomeroom(studentId, homeRoom);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void AddStudent()
        {
            view.DisplayMessage("Enter the new student's first name: ");
            string firstName = view.GetInput();
            view.DisplayMessage("Enter the student's last name: ");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the student's year level: ");
            int yearLevel = view.GetIntInput();
            view.DisplayMessage("Enter the student's homeroom: ");
            string homeRoom = view.GetInput();
            view.DisplayMessage("Enter a username for the student: ");
            string userName = view.GetInput();
            view.DisplayMessage("Enter a password for the student: ");
            string password = view.GetInput();
            int studentID = 0;
            Students student1 = new Students(studentID, lastName, firstName, yearLevel, homeRoom, userName, password);
            int generateId = storageManager.AddStudent(student1);
            Console.WriteLine($"New student inserted with ID: {generateId}");
        }
        private static void DeleteStudentByName()
        {
            view.DisplayMessage("Enter the last name of the student to remove: ");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the first name of the student to remove: ");
            string firstName = view.GetInput();
            int rowsAffected = storageManager.DeleteStudentByName(lastName, firstName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void GroupsChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    List<Groups> groups = storageManager.GetAllGroups();
                    view.DisplayGroups(groups);
                    break;
                case 2:
                    UpdateGroupName();
                    break;
                case 3:
                    InsertNewGroup();
                    break;
                case 4:
                    DeleteGroupByName();
                    break;
            }
        }

        private static void UpdateGroupName()
        {
            view.DisplayMessage("Enter the groupId to update: ");
            int groupId = view.GetIntInput();
            view.DisplayMessage("Enter the new group name: ");
            string groupName = view.GetInput();
            int rowsAffected = storageManager.UpdateGroupName(groupId, groupName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewGroup()
        {
            view.DisplayMessage("Enter the new group name: ");
            string groupName = view.GetInput();
            int groupID = 0;
            Groups group1 = new Groups(groupID, groupName);
            int generateId = storageManager.InsertGroup(group1);
            view.DisplayMessage($"New group inserted with ID: {generateId}");
            
        }

        private static void DeleteGroupByName()
        {
            view.DisplayMessage("Enter the group name to delete: ");
            string groupName = view.GetInput();
            int rowsAffected = storageManager.DeleteGroupByName(groupName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void TeachersChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    List<Teachers> teachers = storageManager.GetAllTeachers();
                    view.DisplayTeachers(teachers);
                    break;
                case 2:
                    UpdateTeacherName();
                    break;
                case 3:
                    AddTeacher();
                    break;
                case 4:
                    DeleteTeacherByName();
                    break;
            }
        }

        private static void UpdateTeacherName()
        {
            view.DisplayMessage("Enter the teacher Id to update: ");
            int teacherId = view.GetIntInput();
            view.DisplayMessage("Enter the new last name: ");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the new first name: ");
            string firstName = view.GetInput();
            int rowsAffected = storageManager.UpdateTeacherName(teacherId, lastName, firstName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }
        private static void GroupsChoice()
        {
            view = new ConsoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<Groups> groups = storageManager.GetAllGroups();
                        view.DisplayGroups(groups);
                    }
                    break;
                case "2":
                    UpdateGroupName();
                    break;
                case "3":
                    InsertNewGroup();
                    break;
                case "4":
                    DeleteGroupByName();
                    break;
                /*case "5":
                    exit = true;
                    break;*/
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
storageManager.CloseConnection();
}
} /*private static void InsertNewGroup()
        {
            view.DisplayMessage("Enter the new group name: ");
            string groupName = view.GetInput();
            int generateId = storageManager.InsertGroup(groupName);
            view.DisplayMessage($"New group inserted with ID: {generateId}");
        }*/