namespace WeatherAPI.Utils
{
    public class ConnectionString
    {
        private const string Server = @"GON\WEATHER";

        private const string DB = @"WeatherDB";
        private const string User = @"sa";
        private const string Password = @"1398632";

        public static string GetSQLString => $"Data Source={Server};" +
                                                 $"Initial Catalog={DB}; " +
                                                 $"User Id={User}; " +
                                                 $"Password={Password};" +
                                                 $"TrustServerCertificate=true;";
    }
}
