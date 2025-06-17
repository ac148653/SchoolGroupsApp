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

        public Teachers(int teacherID, string lastName, string firstName)
        {
            TeacherID = teacherID;
            LastName = lastName;
            FirstName = firstName;
        }
    }
}
