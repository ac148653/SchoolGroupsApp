using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Teachers
    {
        private int TeacherID { get; set; }
        private string LastName { get; set; }
        private string FirstName { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

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
