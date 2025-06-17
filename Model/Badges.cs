using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGroupsApp.Model
{
    public class Badges
    {
        private int BadgeID {  get; set; }
        private string BadgeLevel { get; set; }
        private string BadgeName { get; set; }

        public Badges(int badgeID, string badgeLevel, string badgeName)
        {
            BadgeID = badgeID;
            BadgeLevel = badgeLevel;
            BadgeName = badgeName;
        }

    }
}
