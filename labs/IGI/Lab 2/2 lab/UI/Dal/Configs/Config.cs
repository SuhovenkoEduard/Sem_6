using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Dal.Configs
{
    public static class Config
    {
        private const string Path = @"D:\Projects\University\Sem_6\labs\IGI\Lab 2\2 lab\UI\Dal\Configs\package.json";

        public static string DbConfig()
        {
            var config = JObject.Parse(File.ReadAllText(Path));
            return Convert.ToString(config["dependencies"]["connectionDb"]);
        }
        
    }
}