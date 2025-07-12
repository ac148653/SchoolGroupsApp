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
            view = new ConsoleView();
            int loginChoice, r = 0;
            do
            {
                loginChoice = view.LoginMenu();
                switch (loginChoice)
                {
                    case 1:
                        {
                            r = TeacherLogin();
                            if (r == 1)
                                TeacherMenuChoice();
                            if (r == 2)
                                break;
                        }
                        break;
                    case 2:
                        {
                            //r = view//StudentLogin();
                            if (r == 1)
                                //StudentMenuChoice();
                            if (r == 2)
                                break;
                        }
                        break;
                    case 3:
                        {
                            r = view.StudentRegister();
                            if (r == 1)
                                //StudentMenuChoice();
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

        public static int CheckTeacherLogin(string userName, string password)
        {
            List<Teachers> teachers = storageManager.GetAllTeachers();

            foreach (Teachers teacher in teachers)
            {
                if (userName.Equals(teacher.UserName) && password.Equals(teacher.Password))
                {
                    view.DisplayMessage("Login successful!");
                    return 1;
                }
            }
            view.DisplayMessage("Your username or password is incorrect. Please enter them again.");
            return 0;
        }

        public static int TeacherLogin()
        {
            string userName;
            string password;
            Console.Clear();
            view.DisplayMessage("Welcome to Teacher Login ");
            do
            {
                view.DisplayMessage("LOGIN HERE:");
                view.DisplayMessage("Please enter your username: ");
                userName = Console.ReadLine();
                view.DisplayMessage("Please enter your password: ");
                password = Console.ReadLine();
                if (userName.Length > 10 || userName.Length < 3)
                    view.DisplayMessage("Invalid input. Please enter your username again. It must be between 5 to 10 characters.");
                if (password.Length > 10 || password.Length < 5)
                    view.DisplayMessage("Invalid input. Please enter your password again. It must be between 5 to 10 characters.");
               // view.DisplayMessage("Press 2 to Return to Main Menu or press enter to continue");
                //string input = Console.ReadLine();
                //if (string.IsNullOrEmpty(input))
                  //  break;
                //int x = int.Parse(input);
               // if (x == 2)
                    //return x;
            } while ((userName.Length > 10) || (userName.Length < 3) || (password.Length > 10) || (password.Length < 5));
            int r = CheckTeacherLogin(userName, password);
            if (r == 0)
                TeacherLogin();
            return r;
        }
        private static void TeacherMenuChoice()
        {
            int studentsChoice;
            int groupsChoice;
            int teacherChoice;
            int tasksChoice;
            int badgesChoice;
            int pointsChoice;
            int reportsChoice;
            //do
            //{
                int teacherMenuChoice = view.TeacherMenu();
                switch (teacherMenuChoice)
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
                        {
                            teacherChoice = view.Teachers();
                            if (teacherChoice >= 1 && teacherChoice <= 4)
                                TeachersChoice(teacherChoice);
                            if (teacherChoice == 5)
                                break;
                        }
                        break;
                    case 4:
                        {
                            tasksChoice = view.Tasks();
                            if (tasksChoice >= 1 && tasksChoice <= 6)
                                TasksChoice(tasksChoice);
                            if (tasksChoice == 7)
                                break;
                        }
                        break;
                    case 5:
                        {
                            badgesChoice = view.Badges();
                            if (badgesChoice >= 1 && badgesChoice <= 6)
                                BadgesChoice(badgesChoice);
                            if (badgesChoice == 7)
                                break;
                        }
                        break;
                    case 6:
                        {
                            pointsChoice = view.Points();
                            if (pointsChoice >= 1 && pointsChoice <= 3)
                                PointsChoice(pointsChoice);
                            if (pointsChoice == 4)
                                break;
                        }
                        break;
                    case 7:
                        {
                            reportsChoice = view.Reports();
                            if (reportsChoice >= 1 && reportsChoice <= 15)
                                ReportsChoice(reportsChoice);
                            if(reportsChoice == 16)
                            break;
                        }
                        break;
                    case 8:
                    default:
                        view.DisplayMessage("Invalid option. Please try again.");
                        break;
                }
            //} while //(studentsChoice == 7 || groupsChoice == 5 || teacherChoice == 5 || tasksChoice == 7 || badgesChoice == 7 || pointsChoice == 4);
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

        private static void AddTeacher()
        {
            view.DisplayMessage("Enter the new teacher's first name: ");
            string firstName = view.GetInput();
            view.DisplayMessage("Enter the teacher's last name: ");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter a username for the teacher: ");
            string userName = view.GetInput();
            view.DisplayMessage("Enter a password for the teacher: ");
            string password = view.GetInput();
            int teacherID = 0;
            Teachers teacher1 = new Teachers(teacherID, lastName, firstName, userName, password);
            int generateId = storageManager.AddTeacher(teacher1);
            Console.WriteLine($"New teacher inserted with ID: {generateId}");
        }

        private static void DeleteTeacherByName()
        {
            view.DisplayMessage("Enter the last name of the teacher to remove: ");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the first name of the teacher to remove: ");
            string firstName = view.GetInput();
            int rowsAffected = storageManager.DeleteTeacherByName(lastName, firstName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void TasksChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    List<Tasks> tasks = storageManager.GetAllTasks();
                    view.DisplayTasks(tasks);
                    break;
                case 2:
                    UpdateTaskName();
                    break;
                case 3:
                    UpdatePointsValue();
                    break;
                case 4:
                    AddTask();
                    break;
                case 5:
                    DeleteTaskByName();
                    break;
                case 6:
                    AssignTask();
                    break;
            }
        }

        private static void UpdateTaskName()
        {
            view.DisplayMessage("Enter the task Id to update: ");
            int taskId = view.GetIntInput();
            view.DisplayMessage("Enter the new task name: ");
            string taskName = view.GetInput();
            int rowsAffected = storageManager.UpdateTaskName(taskId, taskName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void UpdatePointsValue()
        {
            view.DisplayMessage("Enter the task Id to update: ");
            int taskId = view.GetIntInput();
            view.DisplayMessage("Enter the new points value: ");
            int pointsValue = view.GetIntInput();
            int rowsAffected = storageManager.UpdatePointsValue(taskId, pointsValue);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void AddTask()
        {
            view.DisplayMessage("Enter the new task's name: ");
            string taskName = view.GetInput();
            view.DisplayMessage("Enter the new task's points value: ");
            int pointsValue = view.GetIntInput();
            view.DisplayMessage("Enter the group name for the task: ");
            string groupName = view.GetInput();
            int groupID = storageManager.GroupID(groupName);
            int taskID = 0;
            Tasks task1 = new Tasks(taskID, taskName, pointsValue, groupID);
            int generateId = storageManager.AddTask(task1);
            Console.WriteLine($"New task inserted with ID: {generateId}");
        }

        private static void DeleteTaskByName()
        {
            view.DisplayMessage("Enter the task name of the task to remove: ");
            string taskName = view.GetInput();
            int rowsAffected = storageManager.DeleteTaskByName(taskName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void AssignTask()
        {
            view.DisplayMessage("Enter the last name of the student you want to assign a task to:");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the first name of the student you want to assign a task to:");
            string firstName = view.GetInput();
            int studentID = storageManager.StudentID(lastName, firstName);
            view.DisplayMessage("Enter the group you want to assign the task for: ");
            string groupName = view.GetInput();
            int groupID = storageManager.GroupID(groupName);
            int studentGroupID = storageManager.StudentGroupID(studentID, groupID);
            view.DisplayMessage("Enter the task you want to assign: ");
            string taskName = view.GetInput();
            int taskID = storageManager.TaskID(taskName);
            int pointsValue = storageManager.TaskPointsValue(taskID);
            int studentTaskPointsID = storageManager.InsertStudentTaskPoints(studentGroupID, taskID, pointsValue);
        }

        private static void BadgesChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    List<Badges> badges = storageManager.GetAllBadges();
                    view.DisplayBadges(badges);
                    break;
                case 2:
                    UpdateBadgeName();
                    break;
                case 3:
                    UpdateBadgeLevel();
                    break;
                case 4:
                    AddBadge();
                    break;
                case 5:
                    DeleteBadgeByName();
                    break;
                case 6:
                    AwardBadge();
                    break;
            }
        }

        private static void UpdateBadgeName()
        {
            view.DisplayMessage("Enter the badge Id to update: ");
            int badgeId = view.GetIntInput();
            view.DisplayMessage("Enter the new badge name: ");
            string badgeName = view.GetInput();
            int rowsAffected = storageManager.UpdateBadgeName(badgeId, badgeName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void UpdateBadgeLevel()
        {
            view.DisplayMessage("Enter the badge Id to update: ");
            int badgeId = view.GetIntInput();
            view.DisplayMessage("Enter the new badge level: ");
            string badgeLevel = view.GetInput();
            int rowsAffected = storageManager.UpdateBadgeLevel(badgeId, badgeLevel);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void AddBadge()
        {
            view.DisplayMessage("Enter the new badge's name: ");
            string badgeName = view.GetInput();
            view.DisplayMessage("Enter the new badge's level: ");
            string badgeLevel = view.GetInput();
            int badgeID = 0;
            Badges badge1 = new Badges(badgeID, badgeName, badgeLevel);
            int generateId = storageManager.AddBadge(badge1);
            Console.WriteLine($"New badge inserted with ID: {generateId}");
        }

        private static void DeleteBadgeByName()
        {
            view.DisplayMessage("Enter the badge name of the badge to remove: ");
            string badgeName = view.GetInput();
            int rowsAffected = storageManager.DeleteBadgeByName(badgeName);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void AwardBadge()
        {
            view.DisplayMessage("Enter the last name of the student you want to award a badge:");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the first name of the student you want to award a badge:");
            string firstName = view.GetInput();
            int studentID = storageManager.StudentID(lastName, firstName);
            view.DisplayMessage("Enter the name of the badge you want to award: ");
            string badgeName = view.GetInput();
            int badgeID = storageManager.BadgeID(badgeName);
            view.DisplayMessage("Enter the name of the group you want to award a badge for:");
            string groupName = view.GetInput();
            int groupID = storageManager.GroupID(groupName);
            int studentGroupID = storageManager.StudentGroupID(studentID, groupID);
            int studentBadgeID = storageManager.InsertStudentBadges(studentGroupID, badgeID);
        }

        private static void PointsChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddPoints();
                    break;
                case 2:
                    List<(string lastName, string firstName, int yearLevel, int totalPoints)> points = storageManager.GetAllPoints();
                    view.DisplayPoints(points);
                    break;
                case 3:
                    DisplayPointsStudent();
                    break;
            }
        }

        private static void AddPoints()
        {
            view.DisplayMessage("Enter the last name of the student you want to give points:");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the first name of the student you want to give points:");
            string firstName = view.GetInput();
            int studentID = storageManager.StudentID(lastName, firstName);
            view.DisplayMessage("Enter the name of the group you want to give points for:");
            string groupName = view.GetInput();
            int groupID = storageManager.GroupID(groupName);
            int studentGroupID = storageManager.StudentGroupID(studentID, groupID);
            view.DisplayMessage("Enter the name of the task you want to give points for: ");
            string taskName = view.GetInput();
            int taskID = storageManager.TaskID(taskName);
            int pointsValue = storageManager.TaskPointsValue(taskID);
            int studentTaskPointsID = storageManager.InsertStudentTaskPoints(studentGroupID, taskID, pointsValue);
        }

        private static void DisplayPointsStudent()
        {
            view.DisplayMessage("Enter the last name of the student you want to view points of:");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter the first name of the student you want to view points of:");
            string firstName = view.GetInput();
            int studentID = storageManager.StudentID(lastName, firstName);
            List<(string lastName, string firstName, int yearLevel, int totalPoints, string groupName)> points = storageManager.GetAllPointsStudent(studentID);
            view.DisplayPointsStudent(points);
        }

        private static void ReportsChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    List<Groups> groups = storageManager.GetAllGroups();
                    view.DisplayGroups(groups);
                    break;
                case 2:
                    List<Students> studentsSenior = storageManager.SeniorStudentsList();
                    view.DisplaySeniorStudents(studentsSenior);
                    break;
                case 3:
                    List<Badges> badges = storageManager.GoldBadges();
                    view.DisplayGoldBadges(badges);
                    break;
                case 4:
                    List<Students> students = storageManager.ParticularHomeroom();
                    view.DisplayParticularHomeroom(students);
                    break;
                case 5:
                    List<Teachers> teachers = storageManager.GetAllTeachers();
                    view.DisplayTeachers(teachers);
                    break;
                case 6:
                    List<(string lastName, string firstName, int yearLevel, string groupName)> studentLeaders = storageManager.StudentLeaders();
                    view.DisplayStudentLeaders(studentLeaders);
                    break;
                case 7:
                    List<(string lastName, string firstName, int yearLevel, string groupName)> studentsWithA = storageManager.StudentsWithA();
                    view.DisplayStudentLeaders(studentsWithA);
                    break;
                case 8:
                    List<(string lastName, string firstName, string badgeLevel, string badgeName)> seniorBadges = storageManager.SeniorBadges();
                    view.DisplaySeniorBadges(seniorBadges);
                    break;
                case 9:
                    List<(string lastName, string firstName)> teachersInChargeDebating = storageManager.TeachersInChargeDebating();
                    view.DisplayTeachersInChargeDebating(teachersInChargeDebating);
                    break;
                case 10:
                    List<(string taskName, int pointsValue, string groupName)> taskGroups = storageManager.TaskGroups();
                    view.DisplayTaskGroups(taskGroups);
                    break;
                case 11:
                    List<(string groupName, int totalStudents)> studentsInMusic = storageManager.StudentsInMusic();
                    view.DisplayStudentsInMusic(studentsInMusic);
                    break;
                case 12:
                    List<(string groupName, int numberOfStudents)> mostPopularGroups = storageManager.MostPopularGroups();
                    view.DisplayMostPopularGroups(mostPopularGroups);
                    break;
                case 13:
                    List<(string groupName, int numberOfTeachers)> teachersInCharge = storageManager.TeachersInCharge();
                    view.DisplayTeachersInCharge(teachersInCharge);
                    break;
                case 14:
                    List<(string groupName, int avgPoints)> averagePoints = storageManager.AveragePoints();
                    view.DisplayAveragePoints(averagePoints);
                    break;
                case 15:
                    List<(string firstName, string lastName, int totalPoints)> leaderPoints = storageManager.LeaderPoints();
                    view.DisplayLeaderPoints(leaderPoints);
                    break;
            }
        }

        private static void StudentMenuChoice()
        {
            int studentMenuChoice = view.StudentMenu();
            switch (studentMenuChoice)
            {
                case 1:
                    List<Groups> groups = storageManager.GetAllGroups();
                    view.DisplayGroups(groups);
                    JoinGroup();
                    break;
                case 2:
                    UnenrollGroup();
                    break;
                case 3:
                    ViewStudentBadges();
                    break;
                case 4:
                    ViewStudentTasks();
                    break;
                case 5:
                    ViewStudentGroups();
                    break;
                case 6:
                    ViewStudentPoints();
                    break;
                case 7:
                    return;
                default:
                    view.DisplayMessage("Invalid option. Please try again.");
                    break;
            }
        }

        private static void JoinGroup()
        {
            view.DisplayMessage("Enter your last name:");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter your first name:");
            string firstName = view.GetInput();
            int studentID = storageManager.StudentID(lastName, firstName);
            view.DisplayMessage("Enter the group you want to join: ");
            string groupName = view.GetInput();
            int groupID = storageManager.GroupID(groupName);
            view.DisplayMessage("Are you a student leader of this group");
            bool leader = view.GetBoolInput();
            int studentGroupID = storageManager.InsertStudentGroups(studentID, groupID, leader);
        }

        private static void UnenrollGroup()
        {
            view.DisplayMessage("Enter your last name:");
            string lastName = view.GetInput();
            view.DisplayMessage("Enter your first name:");
            string firstName = view.GetInput();
            int studentID = storageManager.StudentID(lastName, firstName);
            view.DisplayMessage("Enter the group you want to withdraw from: ");
            string groupName = view.GetInput();
            int groupID = storageManager.GroupID(groupName);
            int studentGroupID = storageManager.DeleteStudentGroup(groupID, studentID);
        }

        private static void ViewStudentBadges()
        {
            int studentID = view.StudentLogin();
            List<(string badgeName, string badgeLevel, string groupName)> viewStudentBadges = storageManager.ViewStudentBadges(studentID);
            foreach ((string badgeName, string badgeLevel, string groupName) viewStudentBadge in viewStudentBadges)
            {
                view.DisplayMessage($"{viewStudentBadge.badgeName}, {viewStudentBadge.badgeLevel}, {viewStudentBadge.groupName}");
            }
        }

        private static void ViewStudentTasks()
        {
            int studentID = view.StudentLogin();
            List<(string taskName, int pointsValue, string groupName)> viewStudentTasks = storageManager.ViewStudentTasks(studentID);
            foreach ((string taskName, int pointsValue, string groupName) viewStudentTask in viewStudentTasks)
            {
                view.DisplayMessage($"{viewStudentTask.taskName}, {viewStudentTask.pointsValue}, {viewStudentTask.groupName}");
            }
        }

        private static void ViewStudentGroups()
        {
            int studentID = view.StudentLogin();
            List<(int groupID, string groupName)> viewStudentGroups = storageManager.ViewStudentGroups(studentID);
            foreach ((int groupID, string groupName) viewStudentGroup in viewStudentGroups)
            {
                view.DisplayMessage($"{viewStudentGroup.groupName}");
            }
        }

        private static void ViewStudentPoints()
        {
            int studentID = view.StudentLogin();
            List<(string groupName, int totalPoints)> viewStudentPoints = storageManager.ViewStudentPoints(studentID);
            foreach ((string groupName, int totalPoints) viewStudentPoint in viewStudentPoints)
            {
                view.DisplayMessage($"{viewStudentPoint.groupName}, {viewStudentPoint.totalPoints}");
            }
        }
    }
}
        /*private static void GroupsChoice()
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
                    break;
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