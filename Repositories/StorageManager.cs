using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SchoolGroupsApp.Model;

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

    }
}
