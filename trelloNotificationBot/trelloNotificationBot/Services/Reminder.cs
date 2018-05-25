using Discord;
using Discord.WebSocket;

using trelloNotificationBot.Model.ConfigTemplates;
using Microsoft.Extensions.Configuration;
using TrelloNet;

using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace trelloNotificationBot.Services
{
    class Reminder
    {

        private readonly DiscordSocketClient discord;
        private readonly IConfigurationRoot config;
        private readonly ITrello trello;
        private readonly IConfigurationRoot boards;

        // DiscordSocketClient and CommandService are injected automatically from the IServiceProvider
        public Reminder(DiscordSocketClient discord, 
            IConfigurationRoot config,
            IConfigurationRoot boards)
        {
            this.discord = discord;
            this.config = config;
            this.boards = boards;
            this.trello = new Trello(this.config["tokens:trello"]);

            Console.Out.WriteLine("test");
        }


        public async Task StartAsync()
        {
            // get board info, sleep until next morning.
        }
    }
}
