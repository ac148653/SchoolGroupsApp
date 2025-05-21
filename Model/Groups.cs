using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Groups
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public Groups(int groupID, string groupName)
        {
            GroupID = groupID;
            GroupName = groupName;
        }//Groups Class
    }
}
