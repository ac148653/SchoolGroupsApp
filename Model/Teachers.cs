using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Teachers
    {
        public int TeacherID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Teachers(int teacherID, string lastName, string firstName, string userName, string password)
        {
            TeacherID = teacherID;
            LastName = lastName;
            FirstName = firstName;
            UserName = userName;
            Password = password;
        }
    }
}
