using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Students
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int YearLevel { get; set; }
        public string HomeRoom { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public Students(int studentID, string lastName, string firstName, int yearLevel, string homeRoom, string userName, string password)
        {
            StudentID = studentID;
            LastName = lastName;
            FirstName = firstName;
            YearLevel = yearLevel;
            HomeRoom = homeRoom;
            UserName = userName;
            Password = password;
        }
    }
}
