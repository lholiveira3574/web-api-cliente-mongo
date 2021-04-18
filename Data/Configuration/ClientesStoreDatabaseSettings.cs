namespace web_api_cliente_mongo.Data.Configuration
{
    public class ClientesStoreDatabaseSettings : IClientesStoreDatabaseSettings
    {
        public string ClientesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IClientesStoreDatabaseSettings
    {
        string ClientesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}