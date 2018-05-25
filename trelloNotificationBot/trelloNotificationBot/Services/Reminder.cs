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
        private const string BOARD_INFO_FILE = "boards.json";
        private IConfiguration _boardInfo;

        private readonly DiscordSocketClient discord;
        private readonly IConfigurationRoot config;
        private readonly ITrello trello;

        // DiscordSocketClient and CommandService are injected automatically from the IServiceProvider
        public Reminder(DiscordSocketClient discord, IConfigurationRoot config)
        {
            this.discord = discord;
            this.config = config;
            this.trello = new Trello(this.config["tokens:trello"]);

            ReadBoardInfo();
        }

        public void ReadBoardInfo()
        {
            // Generate empty JSON configuration file if one does not exist.
            if (!File.Exists(BOARD_INFO_FILE))
            {
                File.Create(BOARD_INFO_FILE).Dispose();

                BoardDictionary configSettings = new BoardDictionary();

                string jsonOutput = JsonConvert.SerializeObject(configSettings, Formatting.Indented);
                File.WriteAllText(BOARD_INFO_FILE, jsonOutput);
            }

            // Read configuration data.
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(BOARD_INFO_FILE, optional: true, reloadOnChange: true);

            _boardInfo = builder.Build();
        }


        public async Task StartAsync()
        {
            // get board info, sleep until next morning.
        }
    }
}
