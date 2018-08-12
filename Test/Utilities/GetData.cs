using System.Configuration;

namespace Test.Utilities
{
    public class GetData
    {
        // Get Base URL from App.config
        public static string BaseAddress => ConfigurationManager.AppSettings["BaseURL"];
    }
}
