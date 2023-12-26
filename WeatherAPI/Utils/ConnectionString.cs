namespace WeatherAPI.Utils
{
    public class ConnectionString
    {
        private const string Server = @"SERVER NAME";

        private const string DB = @"DB NAME";
        private const string User = @"USER";
        private const string Password = @"PASS";

        public static string GetSQLString => $"Data Source={Server};" +
                                                 $"Initial Catalog={DB}; " +
                                                 $"User Id={User}; " +
                                                 $"Password={Password};" +
                                                 $"TrustServerCertificate=true;";
    }
}
