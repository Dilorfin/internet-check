using api.db.models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.db;

internal class DatabaseContext
{
    private readonly Container _container;

    private const string databaseName = "internet";
    private const string containerName = "connections";
    private const string partionKeyName = "/id";

    public DatabaseContext(string connectionString)
    {
        var client = new CosmosClient(connectionString);

        var database = client.CreateDatabaseIfNotExistsAsync(databaseName).Result.Database;

        _container = database.CreateContainerIfNotExistsAsync(containerName, partionKeyName).Result.Container;
    }

    public async Task<IEnumerable<ConnectionModel>> GetAllConnections()
    {
        string query = $@"SELECT * FROM connections";
        var iterator = _container.GetItemQueryIterator<ConnectionModel>(query);
        var matches = new List<ConnectionModel>();
        while (iterator.HasMoreResults)
        {
            var next = await iterator.ReadNextAsync();
            matches.AddRange(next);
        }

        return matches;
    }

    public async Task<ConnectionModel> GetConnection(string id)
    {
        string query = $@"SELECT * FROM connections WHERE connections.id = '{id}'";
        var iterator = _container.GetItemQueryIterator<ConnectionModel>(query);
        var matches = new List<ConnectionModel>();
        while (iterator.HasMoreResults)
        {
            var next = await iterator.ReadNextAsync();
            matches.AddRange(next);
        }
        return matches.SingleOrDefault();
    }

    public async Task ReportConnectionRequestTime(string id, DateTime timestamp)
    {
        ConnectionModel connection = await GetConnection(id);
        await _container.ReplaceItemAsync(connection with { lastRequestTime = timestamp }, id);
    }

    public async Task AddUpdateConnection(ConnectionModel connection)
    {
        await _container.UpsertItemAsync(connection);
    }
}