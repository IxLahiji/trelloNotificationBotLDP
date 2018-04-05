using System;

namespace trelloNotificationBot.Model.ConfigTemplates
{
    public class Tokens
    {
        public string discord { get; set; }
        public string giphy { get; set; }
        public string trello { get; set; }

        public Tokens(string discord = null, string giphy = null, string trello = null)
        {
            this.discord = discord;
            this.giphy = giphy;
            this.trello = trello;
        }
    }
}
