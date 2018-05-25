using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trelloNotificationBot.Model.ConfigTemplates
{
    class BoardDictionary
    {
        public List<Board> boards { get; set; }

        public BoardDictionary()
        {
            this.boards = new List<Board>();
        }
    }
}
