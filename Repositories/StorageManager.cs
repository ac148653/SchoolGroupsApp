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
                        string lastName = reader["LastName"].ToString();
                        string firstName = reader["firstName"].ToString();
                        int yearLevel = Convert.ToInt32(reader["yearLevel"]);
                        string homeRoom = reader["homeroom"].ToString();
                        students.Add(new Students(studentId, lastName, firstName, yearLevel, homeRoom));
                    }
                }
            }
            return students;
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
