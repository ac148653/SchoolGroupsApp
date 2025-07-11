using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SchoolGroupsApp.Model;
using System.Data;

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
                        students.Add(new Students(studentId, lastName, firstName, yearLevel, homeRoom));
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
            string sqlString = "SELECT * FROM Staff.teachers";
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

        public int UpdatePointValue(int taskId, int pointsValue)
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

        public int StudentID(int studentID, string lastName, string firstName)
        {
            using SqlCommand cmd = new SqlCommand("SELECT studentID FROM StudentInvolvement.students WHERE lastName = @LastName AND" +
                "firstName = @FirstName", conn);
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
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
