using Discord;
using Discord.Commands;
using Discord.WebSocket;

using trelloNotificationBot.Services;
using trelloNotificationBot.Model.ConfigTemplates;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace trelloNotificationBot
{
    class Program
    {
        public static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        private IConfigurationRoot _config;
        private IConfigurationRoot _boardInfo;

        private const string CONFIG_FILE = "config.json";
        private const string BOARD_INFO_FILE = "boards.json";

        public async Task StartAsync()
        {
            Console.WriteLine();

            // Load JSON data
            _config = ReadJSONConfig(CONFIG_FILE);
            _boardInfo = ReadJSONConfig(BOARD_INFO_FILE);

            // Begin building the service provider with the following settings.
            // Cache 1000 messages per channel.
            // Force all commands to run async.
            // Verbose logging for both Discord client and Command Service.
            var services = new ServiceCollection()
                .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Verbose,
                    MessageCacheSize = 1000
                }))
                .AddSingleton(new CommandService(new CommandServiceConfig
                {
                    DefaultRunMode = RunMode.Async,
                    LogLevel = LogSeverity.Verbose
                }))
                .AddSingleton<Reminder>()
                .AddSingleton<Commands>()
                .AddSingleton<Startup>()
                .AddSingleton<Logger>()
                .AddSingleton(_config)
                .AddSingleton<Random>();

            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<Logger>();
            await provider.GetRequiredService<Startup>().StartAsync();
            provider.GetRequiredService<Reminder>();
            provider.GetRequiredService<Commands>();

            // Prevent the application from closing.
            await Task.Delay(-1);
        }


        public IConfigurationRoot ReadJSONConfig(string fileName)
        {
            // Generate empty JSON configuration file if one does not exist.
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Dispose();

                BoardDictionary configSettings = new BoardDictionary();

                string jsonOutput = JsonConvert.SerializeObject(configSettings, Formatting.Indented);
                File.WriteAllText(fileName, jsonOutput);
            }

            // Read configuration data.
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(fileName, optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
