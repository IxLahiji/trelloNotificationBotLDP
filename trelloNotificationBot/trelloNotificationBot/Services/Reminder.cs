using Discord;
using Discord.WebSocket;
using TrelloNet;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace trelloNotificationBot.Services
{
    class Reminder
    {
        private readonly DiscordSocketClient discord;
        private readonly IConfigurationRoot config;
        private readonly ITrello trello;

        // DiscordSocketClient and CommandService are injected automatically from the IServiceProvider
        public Reminder(DiscordSocketClient discord, IConfigurationRoot config)
        {
            this.discord = discord;
            this.config = config;
            this.trello = new Trello(this.config["tokens:trello"]);
        }


        public async Task StartAsync()
        {
            // get board info, sleep until next morning.
        }
    }
}
