using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Tasks
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int PointsValue { get; set; }
        public int GroupID { get; set; }

        public Tasks(int taskID, string taskName, int pointsValue, int groupID)
        {
            TaskID = taskID;
            TaskName = taskName;
            PointsValue = pointsValue;
            GroupID = groupID;
        }
    }
}
