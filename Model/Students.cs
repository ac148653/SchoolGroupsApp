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
        private int StudentID { get; set; }
        private string LastName { get; set; }
        private string FirstName { get; set; }
        private int Year { get; set; }
        private string HomeRoom { get; set; }

        public Students(int studentID, string lastName, string firstName, int year, string homeRoom)
        {
            StudentID = studentID;
            LastName = lastName;
            FirstName = firstName;
            Year = year;
            HomeRoom = homeRoom;
        }
    }
}
