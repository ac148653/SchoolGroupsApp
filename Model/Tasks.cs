using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Tasks
    {
        private int TaskID { get; set; }
        private string TaskName { get; set; }
        private int PointsValue { get; set; }
        private int GroupID { get; set; }

        public Tasks(int taskID, string taskName, int pointsValue, int groupID)
        {
            TaskID = taskID;
            TaskName = taskName;
            PointsValue = pointsValue;
            GroupID = groupID;
        }
    }
}
