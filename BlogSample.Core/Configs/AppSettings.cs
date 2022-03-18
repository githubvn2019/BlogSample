using Microsoft.Extensions.Configuration;

namespace BlogSample.Core.Configs
{
    public class AppSettings
    {
        public static AppSettings Instance { get; set; }
        public static IConfiguration Configs { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string BlogSample { get; set; }
    }
}
