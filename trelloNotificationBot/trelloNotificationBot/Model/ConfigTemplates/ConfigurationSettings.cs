using System;

namespace trelloNotificationBot.Model.ConfigTemplates
{
    public class ConfigurationSettings
    {
        public string prefix { get; set; }
        public Tokens tokens { get; set; }

        public ConfigurationSettings(string prefix = "!")
        {
            this.prefix = prefix;
            this.tokens = new Tokens();
        }
    }
}
