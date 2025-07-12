using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SchoolGroupsApp.Model;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;

namespace SchoolGroupsApp.Repositories
{
    public class StorageManager
    {
        private SqlConnection conn;
        // this is the storage manager
        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection successful");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connection NOT successful\n");
                Console.WriteLine(e.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);

            }
        }

        public List<Students> GetAllStudents()
        {
            List<Students> students  = new List<Students>();
            string sqlString = "SELECT * FROM StudentInvolvement.students";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentId = Convert.ToInt32(reader["studentID"]);
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        string homeRoom = reader["homeroom"].ToString();
                        string userName = reader["userName"].ToString();
                        string password = reader["password"].ToString();
                        students.Add(new Students(studentId, lastName, firstName, yearLevel, homeRoom, userName, password));
                    }
                }
            }
            return students;
        }

        public int AddStudent(Students student1)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom, userName, password) " +
                "VALUES (@LastName, @FirstName, @YearLevel, @HomeRoom, @UserName, @Password); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@LastName", student1.LastName);
                cmd.Parameters.AddWithValue("@FirstName", student1.FirstName);
                cmd.Parameters.AddWithValue("@YearLevel", student1.YearLevel);
                cmd.Parameters.AddWithValue("@HomeRoom", student1.HomeRoom);
                cmd.Parameters.AddWithValue("@UserName", student1.UserName);
                cmd.Parameters.AddWithValue("@Password", student1.Password);
                    
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int UpdateStudentName(int studentId, string lastName, string firstName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE StudentInvolvement.students SET lastName = @LastName, firstName = @FirstName WHERE lastName = @LastName AND firstName = @FirstName", conn))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateStudentYear(int studentId, int yearLevel)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE StudentInvolvement.students SET yearLevel = @YearLevel WHERE yearLevel = @YearLevel", conn))
            {
                cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                return cmd.ExecuteNonQuery();
            }
        }
        public int UpdateStudentHomeroom(int studentId, string homeRoom)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE StudentInvolvement.students SET homeroom = @Homeroom WHERE homeroom = @homeroom", conn))
            {
                cmd.Parameters.AddWithValue("@HomeRoom", homeRoom);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                return cmd.ExecuteNonQuery();
            }
        }
        public int DeleteStudentByName(string lastName, string firstName)
        {
            using SqlCommand cmd = new SqlCommand("DELETE FROM SchoolInvolvement.students WHERE lastName " +
                "= @LastName AND firstName = @FirstName", conn);
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Teachers> GetAllTeachers()
        {
            List<Teachers> teachers = new List<Teachers>();
            string sqlString = "SELECT * FROM Staff.teachers ORDER BY lastName, firstName";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int teacherId = Convert.ToInt32(reader["teacherID"]);
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        string userName = reader["userName"].ToString();
                        string password = reader["password"].ToString();
                        teachers.Add(new Teachers(teacherId, lastName, firstName, userName, password));
                    } 
                }
            }
            return teachers;
        }

        public int UpdateTeacherName(int teacherId, string lastName, string firstName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Staff.teachers SET lastName = @LastName, firstName = @FirstName WHERE lastName = @LastName AND firstName = @FirstName", conn))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int AddTeacher(Teachers teacher1)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO Staff.teachers (lastName, firstName, userName, password) " +
                "VALUES (@LastName, @FirstName, @UserName, @Password); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@LastName", teacher1.LastName);
                cmd.Parameters.AddWithValue("@FirstName", teacher1.FirstName);
                cmd.Parameters.AddWithValue("@UserName", teacher1.UserName);
                cmd.Parameters.AddWithValue("@Password", teacher1.Password);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteTeacherByName(string lastName, string firstName)
        {
            using SqlCommand cmd = new SqlCommand("DELETE FROM Staff.teachers WHERE lastName " +
                "= @LastName AND firstName = @FirstName", conn);
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                return cmd.ExecuteNonQuery();
            }
        }


        public List<Badges> GetAllBadges()
        {
            List<Badges> badges = new List<Badges>();
            string sqlString = "SELECT * FROM GroupManagement.Badges";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int badgeId = Convert.ToInt32(reader["badgeID"]);
                        string badgeLevel = reader["badgeLevel"].ToString();
                        string badgeName = reader["badgeName"].ToString();
                        badges.Add(new Badges(badgeId, badgeLevel, badgeName));
                    }
                }
            }
            return badges;
        }

        public int UpdateBadgeName(int badgeId, string badgeName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE GroupManagement.Badges SET badgeName = @BadgeName WHERE badgeName = @BadgeName", conn))
            {
                cmd.Parameters.AddWithValue("@BadgeName", badgeName);
                cmd.Parameters.AddWithValue("@BadgeID", badgeId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateBadgeLevel(int badgeId, string badgeLevel)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE GroupManagement.Badges SET badgeLevel = @BadgeLevel WHERE badgeLevel = @BadgeLevel", conn))
            {
                cmd.Parameters.AddWithValue("@BadgeLevel", badgeLevel);
                cmd.Parameters.AddWithValue("@BadgeID", badgeId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int AddBadge(Badges badge1)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO GroupManagement.Badges (badgeName, badgeLevel) " +
                "VALUES (@BadgeName, BadgeLevel); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@BadgeName", badge1.BadgeName);
                cmd.Parameters.AddWithValue("@BadgeLevel", badge1.BadgeLevel);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteBadgeByName(string badgeName)
        {
            using SqlCommand cmd = new SqlCommand("DELETE FROM GroupManagement.Badges WHERE badgeName = @BadgeName", conn);
            {
                cmd.Parameters.AddWithValue("@LastName", badgeName);
                return cmd.ExecuteNonQuery();
            }
        }

        public int BadgeID(string badgeName)
        {
            using SqlCommand cmd = new SqlCommand("SELECT badegID FROM GroupManagement.Badges WHERE badgeName = @BadgeName", conn);
            {
                cmd.Parameters.AddWithValue("@BadgeName", badgeName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertStudentBadges(int studentGroupID, int badgeID)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) " +
                "VALUES (@StudentGroupID, @BadgeID); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@StudentGroupID", studentGroupID);
                cmd.Parameters.AddWithValue("@BadgeID", badgeID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<Tasks> GetAllTasks()
        {
            List<Tasks> tasks = new List<Tasks>();
            string sqlString = "SELECT * FROM GroupManagement.tasks";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int taskId = Convert.ToInt32(reader["taskID"]);
                        string taskName = reader["taskName"].ToString();
                        int pointsValue = Convert.ToInt32(reader["pointsValue"].ToString());
                        int groupId = Convert.ToInt32(reader["groupID"]);
                        tasks.Add(new Tasks(taskId, taskName, pointsValue, groupId));
                    }
                }
            }
            return tasks;
        }

        public int UpdateTaskName(int taskId, string taskName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE GroupManagement.tasks SET taskName = @TaskName WHERE taskName = @TaskName", conn))
            {
                cmd.Parameters.AddWithValue("@TaskName", taskName);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdatePointsValue(int taskId, int pointsValue)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE GroupManagement.tasks SET pointsValue = @PointsValue WHERE pointsValue = @PointsValue", conn))
            {
                cmd.Parameters.AddWithValue("@PointsValue", pointsValue);
                cmd.Parameters.AddWithValue("@TaskID", taskId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int AddTask(Tasks task1)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO GroupManangement.tasks (taskName, pointsValue, groupID) " +
                "VALUES (@TaskName, @PointsValue, @GroupID); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@TaskName", task1.TaskName);
                cmd.Parameters.AddWithValue("@PointsValue", task1.PointsValue);
                cmd.Parameters.AddWithValue("@GroupID", task1.GroupID);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteTaskByName(string taskName)
        {
            using SqlCommand cmd = new SqlCommand("DELETE FROM GroupManagement.tasks WHERE taskName " +
                "= @TaskName", conn);
            {
                cmd.Parameters.AddWithValue("@TaskName", taskName);
                return cmd.ExecuteNonQuery();
            }
        }

        public int StudentID(string lastName, string firstName)
        {
            using SqlCommand cmd = new SqlCommand("SELECT studentID FROM StudentInvolvement.students WHERE lastName = @LastName AND" +
                "firstName = @FirstName", conn);
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GroupID(string groupName)
        {
            using SqlCommand cmd = new SqlCommand("SELECT groupID FROM GroupManagement.groups WHERE groupName = @GroupName", conn);
            {
                cmd.Parameters.AddWithValue("@GroupName", groupName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int TaskID(string taskName)
        {
            using SqlCommand cmd = new SqlCommand("SELECT taskID FROM GroupManagement.tasks WHERE taskName = @TaskName", conn);
            {
                cmd.Parameters.AddWithValue("@TaskName", taskName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int TaskPointsValue(int taskID)
        {
            using SqlCommand cmd = new SqlCommand("SELECT pointsValue FROM GroupManagement.tasks WHERE taskID = @TaskID", conn);
            {
                cmd.Parameters.AddWithValue("@TaskID", taskID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        
        public int StudentGroupID(int studentID, int groupID)
        {
            using SqlCommand cmd = new SqlCommand("SELECT studentGroupID FROM StudentInvolvement.studentGroups WHERE studentID = @StudentID" +
                "AND groupID = @GroupID", conn);
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertStudentTaskPoints(int studentGroupID, int taskID, int points)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) " +
                "VALUES (@StudentGroupID, @TaskID, @Points); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@StudentGroupID", studentGroupID);
                cmd.Parameters.AddWithValue("@TaskID", taskID);
                cmd.Parameters.AddWithValue("@Points", points);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Groups> GetAllGroups()
        {
            List<Groups> groups = new List<Groups>();
            string sqlString = "SELECT * FROM GroupManagement.groups";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int groupId = Convert.ToInt32(reader["groupID"]);
                        string groupName = reader["groupName"].ToString();
                        groups.Add(new Groups(groupId, groupName));
                    }
                }
            }
            return groups;
        }

        public int UpdateGroupName(int groupId, string groupName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE GroupManagement.groups SET groupName = @GroupName WHERE groupName = @GroupName", conn))
            {
                cmd.Parameters.AddWithValue("@GroupName", groupName);
                cmd.Parameters.AddWithValue("@GroupID", groupId);   
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertGroup(Groups group1)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO GroupManagement.groups (groupName) " +
                "VALUES (@GroupName); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@GroupName", group1.GroupName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }  
        }
        public int DeleteGroupByName(string groupName)
        {
            using SqlCommand cmd = new SqlCommand("DELETE FROM GroupManagement.groups WHERE groupName " +
                "= @GroupName", conn);
            {
                cmd.Parameters.AddWithValue("@GroupName", groupName);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<(string lastName, string firstName, int yearLevel, int totalPoints)> GetAllPoints()
        {
            List<(string lastName, string firstName, int yearLevel, int totalPoints)> points = new List<(string lastName, string firstName, int yearLevel, int totalPoints)>();
            string sqlString = "SELECT S.firstName, S.lastName, S.yearLevel, SUM(STP.Points) AS totalPoints FROM StudentInvolvement.students S, " +
                "StudentInvolvement.studentGroups SG, StudentInvolvement.studentTaskPoints STP WHERE S.studentID = SG.studentID AND " +
                "SG.studentGroupID = STP.studentGroupID GROUP BY S.studentID, S.firstName, S.lastName, S.yearLevel" +
                "ORDER BY S.yearLevel, S.lastName, S.firstName, totalPoints DESC";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = reader["lastName"].ToString();
                        string lastName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        int totalPoints = Convert.ToInt32(reader["totalPoints"]);
                        points.Add((lastName, firstName, yearLevel, totalPoints));
                    }
                }
            }
            return points;
        }

        public List<(string lastName, string firstName, int yearLevel, int totalPoints, string groupName)> GetAllPointsStudent(int studentID)
        {
            List<(string lastName, string firstName, int yearLevel, int totalPoints, string groupName)> points = new List<(string lastName, string firstName, int yearLevel, int totalPoints, string groupName)>();
            string sqlString = "SELECT S.firstName, S.lastName, S.yearLevel, G.groupName, SUM(STP.Points) AS totalPoints FROM StudentInvolvement.students S, GroupManagement.groups G, " +
                "StudentInvolvement.studentGroups SG, StudentInvolvement.studentTaskPoints STP WHERE S.studentID = SG.studentID AND G.groupID = SG.groupID AND " +
                "SG.studentGroupID = STP.studentGroupID AND S.studentID = @StudentID GROUP BY S.studentID, S.firstName, S.lastName, S.yearLevel, S.groupName" +
                "ORDER BY S.yearLevel, S.lastName, S.firstName, totalPoints DESC";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = reader["lastName"].ToString();
                        string lastName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        int totalPoints = Convert.ToInt32(reader["totalPoints"]);
                        string groupName = reader["groupName"].ToString();
                        points.Add((lastName, firstName, yearLevel, totalPoints, groupName));
                    }
                }
                cmd.Parameters.AddWithValue("@StudentID", studentID);
            }
            return points;
        }

        public List<Students> SeniorStudentsList()
        {
            List<Students> students = new List<Students>();
            string sqlString = "SELECT lastName, firstName, yearLevel, homeroom FROM StudentInvolvement.students WHERE yearLevel = 13 ORDER BY yearLevel, homeroom, lastName, firstName";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentId = Convert.ToInt32(reader["studentID"]);
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        string homeRoom = reader["homeroom"].ToString();
                    }
                }
            }
            return students;
        }

        public List<> GoldBadges()
        {
            List<Badges> badges = new List<Badges>();
            using SqlCommand cmd = new SqlCommand("SELECT badgeName FROM GroupManagement.Badges WHERE badgeLevel = 'Gold'", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string badgeName = reader["badgeName"].ToString();
                        Badges badge = new Badges();
                        badge.BadgeName = badgeName;
                        badges.Add(badge);
                    }
                }
            }
            return badges;
        }

        public List<Students> ParticularHomeroom()
        {
            List<Students> students = new List<Students>();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM StudentInvolvement.students WHERE homeroom = '12GRG' ORDER BY lastName, firstName", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentID = Convert.ToInt32(reader["studentID"]);
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        string homeroom = reader["homeroom"].ToString();
                        string userName = reader["userName"].ToString();
                        string password = reader["password"].ToString();
                        students.Add(new Students(studentID, lastName, firstName, yearLevel, homeroom, userName, password));
                    }
                }
            }
            return students;
        }

        public List<(string lastName, string firstName, int yearlevel, string groupName)> StudentLeaders()
        {
            List<(string lastName, string firstName, int yearlevel, string groupName)> studentLeaders = new List<(string lastName, string firstName, int yearlevel, string groupName)>();
            using SqlCommand cmd = new SqlCommand("SELECT S.lastName, S.firstName, S.yearLevel, G.groupName FROM StudentInvolvement.students S, " +
                "GroupManagement.groups G, StudentInvolvement.studentGroups SG WHERE S.studentID = SG.studentID AND G.groupID = SG.groupID AND " +
                "leader = 1 ORDER BY G.groupName, S.yearLevel DESC, S.lastName", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        string groupName = reader["groupName"].ToString();
                        studentLeaders.Add(new (lastName, firstName, yearLevel, groupName));
                    }
                }
            }
            return studentLeaders;
        }

        public List<(string lastName, string firstName, int yearlevel, string groupName)> StudentsWithA()
        {
            List<(string lastName, string firstName, int yearlevel, string groupName)> studentsWithA = new List<(string lastName, string firstName, int yearlevel, string groupName)>();
            using SqlCommand cmd = new SqlCommand("SELECT S.lastName, S.firstName, S.yearLevel, G.groupName FROM " +
                "StudentInvolvement.students S, GroupManagement.groups G, StudentInvolvement.studentGroups SG " +
                "WHERE S.studentID = SG.studentID AND G.groupID = SG.groupID AND S.firstName LIKE 'A%' ", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        string groupName = reader["groupName"].ToString();
                        studentsWithA.Add(new(lastName, firstName, yearLevel, groupName));
                    }
                }
            }
            return studentsWithA;
        }

        public List<(string lastName, string firstName, string badgeLevel, string badgeName)> SeniorBadges()
        {
            List<(string lastName, string firstName, string badgeLevel, string badgeName)> seniorBadges = new List<(string lastName, string firstName, string badgeLevel, string badgeName)>();
            using SqlCommand cmd = new SqlCommand("SELECT S.lastName, S.firstName, B.badgeLevel, B.badgeName FROM " +
                "StudentInvolvement.students S, StudentInvolvement.studentBadges SB, GroupManagement.badges B, " +
                "StudentInvolvement.studentGroups SG WHERE S.studentID = SG.studentID AND SG.studentGroupID = SB.studentGroupID " +
                "AND B.badgeID = SB.badgeID AND S.yearLevel = 13", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        string badgeLevel = reader["badgeLevel"].ToString();
                        string badgeName = reader["badgeName"].ToString();
                        seniorBadges.Add(new(lastName, firstName, badgeLevel, badgeName));
                    }
                }
            }
            return seniorBadges;
        }

        public List<(string lastName, string firstName)> TeachersInChargeDebating()
        {
            List<(string lastName, string firstName)> teachersInChargeDebating = new List<(string lastName, string firstName)>();
            using SqlCommand cmd = new SqlCommand(" SELECT T.lastName, T.firstName FROM Staff.teacherGroups TG, " +
                "Staff.teachers T, GroupManagement.groups G WHERE T.teacherID = TG.teacherID AND G.groupID = TG.groupID " +
                "AND G.groupName = 'Debating' ORDER BY T.lastName", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string lastName = reader["lastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        teachersInChargeDebating.Add(new(lastName, firstName));
                    }
                }
            }
            return teachersInChargeDebating;
        }

        public List<(string taskName, int pointsValue, string groupName)> TaskGroups()
        {
            List<(string taskName, int pointsValue, string groupName)> taskGroups = new List<(string taskName, int pointsValue, string groupName)>();
            using SqlCommand cmd = new SqlCommand("SELECT T.taskName, T.pointsValue, G.groupName FROM GroupManagement.tasks T, " +
                "GroupManagement.groups G WHERE G.groupID= T.groupID AND T.pointsValue>=5 ORDER BY T.pointsValue DESC", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string taskName = reader["taskName"].ToString();
                        int pointsValue = Convert.ToInt32(reader["pointsValue"]);
                        string groupName = reader["groupName"].ToString();
                        taskGroups.Add(new(taskName, pointsValue, groupName));
                    }
                }
            }
            return taskGroups;
        }

        public List<(string groupName, int totalStudents)> StudentsInMusic()
        {
            List<(string groupName, int totalStudents)> studentsInMusic = new List<(string groupName, int totalStudents)>();
            using SqlCommand cmd = new SqlCommand("SELECT G.groupName, Count (S.studentID) AS totalStudents FROM " +
                "StudentInvolvement.students S, GroupManagement.groups G, StudentInvolvement.studentGroups SG WHERE " +
                "SG.GroupID = G.GroupID AND SG.StudentID = S.StudentID GROUP BY G.groupName HAVING G.groupName IN ('Choir', 'Orchestra')", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string groupName = reader["groupName"].ToString();
                        int totalStudents = Convert.ToInt32(reader["totalStudents"]);
                        studentsInMusic.Add(new(groupName, totalStudents));
                    }
                }
            }
            return studentsInMusic;
        }

        public List<(string groupName, int NumberOfStudents)> MostPopularGroups()
        {
            List<(string groupName, int numberOfStudents)> mostPopularGroups = new List<(string groupName, int numberOfStudents)>();
            using SqlCommand cmd = new SqlCommand("SELECT TOP 5 G.groupName, Count (S.studentID) AS NumberOfStudents FROM " +
                "StudentInvolvement.students S, GroupManagement.groups G, StudentInvolvement.studentGroups SG  WHERE G.GroupID = SG.GroupID " +
                "AND S.StudentID = SG.StudentID GROUP BY G.groupName ORDER BY NumberOfStudents DESC", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string groupName = reader["groupName"].ToString();
                        int numberOfStudents = Convert.ToInt32(reader["NumberOfStudents"]);
                        mostPopularGroups.Add(new(groupName, numberOfStudents));
                    }
                }
            }
            return mostPopularGroups;
        }

        public List<(string groupName, int NumberOfTeachers)> TeachersInCharge()
        {
            List<(string groupName, int numberOfTeachers)> teachersInCharge = new List<(string groupName, int numberOfTeachers)>();
            using SqlCommand cmd = new SqlCommand("SELECT G.groupName, Count (T.teacherID) AS NumberOfTeachers " +
                "FROM Staff.teacherGroups TG, Staff.teachers T, GroupManagement.groups G " +
                "WHERE T.teacherID=TG.teacherID AND G.groupID=TG.groupID nGROUP BY G.groupName", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string groupName = reader["groupName"].ToString();
                        int numberOfTeachers = Convert.ToInt32(reader["NumberOfTeachers"]);
                        teachersInCharge.Add(new(groupName, numberOfTeachers));
                    }
                }
            }
            return teachersInCharge;
        }

        public List<(string groupName, int avgPoints)> AveragePoints()
        {
            List<(string groupName, int avgPoints)> averagePoints = new List<(string groupName, int avgPoints)>();
            using SqlCommand cmd = new SqlCommand("SELECT G.groupName, AVG(TP.points) AS avgPoints FROM GroupManagement.groups G, " +
                "StudentInvolvement.studentGroups SG, StudentInvolvement.studentTaskPoints TP WHERE G.groupID = SG.groupID " +
                "AND SG.studentGroupID = TP.studentGroupID GROUP BY G.groupName ORDER BY avgPoints DESC", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string groupName = reader["groupName"].ToString();
                        int avgPoints = Convert.ToInt32(reader["avgPoints"]);
                        averagePoints.Add(new(groupName, avgPoints));
                    }
                }
            }
            return averagePoints;
        }

        public List<(string firstName, string lastName, int totalPoints)> LeaderPoints()
        {
            List<(string firstName, string lastName, int totalPoints)> leaderPoints = new List<(string firstName, string lastName, int totalPoints)>();
            using SqlCommand cmd = new SqlCommand("SELECT S.firstName, S.lastName, SUM(TP.points) AS totalPoints FROM " +
                "StudentInvolvement.students S, StudentInvolvement.studentGroups SG, StudentInvolvement.studentTaskPoints TP " +
                "WHERE S.studentID = SG.studentID AND SG.studentGroupID = TP.studentGroupID AND SG.leader = 1 GROUP BY S.firstName, " +
                "S.lastName ORDER BY totalPoints DESC", conn);
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = reader["firstName"].ToString();
                        string lastName = reader["lastName"].ToString();
                        int totalPoints = Convert.ToInt32(reader["totalPoints"]);
                        leaderPoints.Add(new(firstName, lastName, totalPoints));
                    }
                }
            }
            return leaderPoints;
        }

        public int InsertStudentGroups(int studentID, int groupID, bool leader)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) " +
                "VALUES (@StudentID, @GroupID, @Leader); SELECT SCOPE_IDENTITY();", conn);
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                cmd.Parameters.AddWithValue("@Leader", leader);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteStudentGroup(int groupID, int studentID)
        {
            using SqlCommand cmd = new SqlCommand("DELETE FROM StudentInvolvement.studentGroups WHERE groupID " +
                "= @GroupID AND studentID = @StudentID", conn);
            {
                cmd.Parameters.AddWithValue("@GroupID", groupID);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<(string badgeName, string badgeLevel, string groupName)> ViewStudentBadges(int studentID)
        {
            List<(string badgeName, string badgeLevel, string groupName)> viewStudentBadges = new List<(string badgeName, string badgeLevel, string groupName)>();
            using SqlCommand cmd = new SqlCommand("SELECT B.badgeName, B.badgeLevel, G.groupName FROM GroupManagement.Badges B, StudentInvolvement.studentBadges SB, " +
                "GroupManagement.groups G, StudentInvolvement.studentGroups SG WHERE B.badgeID = SB.badgeID AND B.studentGroupID = SG.studentGroupID AND " +
                "G.groupID = SG.groupID AND SG.studentID = @StudentID");
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string badgeName = reader["badgeName"].ToString();
                        string badgeLevel = reader["badgeLevel"].ToString();
                        string groupName = reader["groupName"].ToString();
                        viewStudentBadges.Add(new(badgeName, badgeLevel, groupName));
                    }
                }
            }
            return viewStudentBadges;
        }

        public List<(string taskName, int pointsValue, string groupName)> ViewStudentTasks(int studentID)
        {
            List<(string taskName, int pointsValue, string groupName)> viewStudentTasks = new List<(string taskName, int pointsValue, string groupName)>();
            using SqlCommand cmd = new SqlCommand("SELECT T.taskName, T.pointsValue, G.groupName FROM GroupManagement.tasks T, " +
                "GroupManagement.groups G, StudentInvolvement.studentGroups SG, StudentInvolvement.studentTaskPoints STP WHERE T.taskID = STP.taskID AND " +
                "STP.studentGroupID = SG.studentGroupID AND G.groupID = SG.groupID AND SG.studentID = @StudentID");
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string taskName = reader["taskName"].ToString();
                        int pointsValue = Convert.ToInt32(reader["pointsValue"]);
                        string groupName = reader["groupName"].ToString();
                        viewStudentTasks.Add(new(taskName, pointsValue, groupName));
                    }
                }
            }
            return viewStudentTasks;
        }

        public List<(int groupID, string groupName)> ViewStudentGroups(int studentID)
        {
            List<(int groupID, string groupName)> viewStudentGroups = new List<(int groupID, string groupName)>();
            using SqlCommand cmd = new SqlCommand("SELECT G.groupID, G.groupName FROM GroupManagement.groups G, StudentInvolvement.studentGroups SG WHERE " +
                "G.groupID = SG.groupID AND SG.studentID = @StudentID");
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int groupID = Convert.ToInt32(reader["groupID"]);
                        string groupName = reader["groupName"].ToString();
                        viewStudentGroups.Add(new(groupID, groupName));
                    }
                }
            }
            return viewStudentGroups;
        }
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

    }
}
