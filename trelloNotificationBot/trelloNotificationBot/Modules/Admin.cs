using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using trelloNotificationBot.Model.ConfigTemplates;
using Microsoft.Extensions.Configuration;
using TrelloNet;

using Discord;
using Discord.Commands;

namespace trelloNotificationBot.Modules
{
    [Name("Admin")]
    [Summary("Commands that can be invoked anywhere, by anyone.")]
    [RequireContext(ContextType.Guild)]
    class Admin : ModuleBase<SocketCommandContext>
    {

        [Command("connectToBoard")]
        [Summary("Connects current channel to a specified board.")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task ConnectToBoard()
        {
            //TODO
            
        }
    }
}
