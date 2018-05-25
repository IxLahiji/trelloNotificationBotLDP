using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trelloNotificationBot.Model.ConfigTemplates
{
    class Member
    {
        public string trelloID { get; set; }
        public string discordID { get; set; }

        public Member(string trelloID)
        {
            this.trelloID = trelloID;
            this.discordID = "";
        }
    }
}
