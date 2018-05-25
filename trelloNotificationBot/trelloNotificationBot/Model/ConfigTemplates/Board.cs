using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trelloNotificationBot.Model.ConfigTemplates
{
    class Board
    {
        public string name { get; set; }
        public List<Member> members { get; set; }

        public Board(string name, List<Member> members)
        {
            this.name = name;
            this.members = members;
        }
    }
}
