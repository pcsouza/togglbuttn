using System;
using System.Collections.Generic;
using System.Text;

namespace TogglButtn.Config
{
    internal class EnvironmentConfig : IConfig {
        public static string TOGGL_API = "TogglAPIKey";
        public EnvironmentConfig() { }

        public string TogglApiKey {
            get {
                return Environment.GetEnvironmentVariable(TOGGL_API);
            }
        }
    }
}
