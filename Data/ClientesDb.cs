using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using web_api_cliente_mongo.Data.Configuration;
using web_api_cliente_mongo.Entities;

namespace web_api_cliente_mongo.Data
{
    public class ClientesDb
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClientesDb(IClientesStoreDatabaseSettings settings)
        {
            var mdbClient = new MongoClient(settings.ConnectionString);

            var database = mdbClient.GetDatabase(settings.DatabaseName);

            _clientesCollection = database.GetCollection<Cliente>(settings.ClientesCollectionName);
        }

       public async Task<List<Cliente>> Get()
        {
            return await _clientesCollection.Find(cli => true).ToListAsync();
        }

        public async Task<Cliente> GetById(string id)
        {
            var cli = await _clientesCollection.FindAsync(cliente => cliente.Id == id);

            return await cli.FirstOrDefaultAsync();
        }

        public async Task<Cliente> Create(Cliente cli)
        {
            await _clientesCollection.InsertOneAsync(cli);
            return cli;
        }

        public async Task Update(string id, Cliente cli)
        {
            await _clientesCollection.ReplaceOneAsync(cliente => cliente.Id == id, cli);
        }

        public async Task DeleteById(string id)
        {
            await _clientesCollection.DeleteOneAsync(cliente => cliente.Id == id);
        }
    }
}