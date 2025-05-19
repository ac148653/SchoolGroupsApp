using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Groups
    {
        private int GroupID { get; set; }
        private string GroupName { get; set; }

        public Groups(int groupID, string groupName)
        {
            GroupID = groupID;
            GroupName = groupName;
        }//Groups Class
    }
}
