namespace FilePro.Data
{
    public class Connection
    {
        private readonly IConfiguration _configuration;
        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("FilePro");
        }
    }
}
