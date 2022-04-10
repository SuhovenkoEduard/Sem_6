using Newtonsoft.Json.Linq;

namespace DAL.Configs;

public static class Config
{
    private const string PathToPackage = "../../../../DAL/Configs/package.json";

    public static string DbConfig()
    {
        var config = JObject.Parse(File.ReadAllText(PathToPackage));
        return Convert.ToString(config["dependencies"]?["connectionDb"]) ?? string.Empty;
    }
}