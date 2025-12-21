namespace WebApiDemo.Authority
{
    public static class AppRepository
    {
        private static List<Application> _apps = new()
        {
            new Application
            {
                AppId = 1,
                AppName = "MVCWebApp",
                ClientId = "53D3C1E6-4587-4AD5-8C6E-A8E4BD59940E",
                Secret = "0673FC70-0514-4011-B4A3-DF9BC03201BC",
                Scopes = "read,write,delete"
            }
        };

        public static Application? GetByClientId(string clientId)
        {
            return _apps.FirstOrDefault(a => a.ClientId == clientId);
        }
    }
}
