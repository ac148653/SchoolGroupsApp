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
        private string BadgeType { get; set; }
        private string BadgeName { get; set; }

        public Badges(int badgeID, string badgeType, string badgeName)
        {
            BadgeID = badgeID;
            BadgeType = badgeType;
            BadgeName = badgeName;
        }

    }
}
