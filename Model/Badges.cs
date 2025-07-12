using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Badges
    {
        public int BadgeID {  get; set; }
        public string BadgeLevel { get; set; }
        public string BadgeName { get; set; }

        public Badges() {}
        public Badges(int badgeID, string badgeLevel, string badgeName)
        {
            BadgeID = badgeID;
            BadgeLevel = badgeLevel;
            BadgeName = badgeName;
        }

    }
}
