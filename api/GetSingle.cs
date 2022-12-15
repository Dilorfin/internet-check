using api.db;
using api.db.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace api;

public static class GetSingle
{
    // TODO: fix "security" issue
    [FunctionName("GetSingle")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        string id = req.Query["id"];

        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        var dbContext = new DatabaseContext(connectionString);
        
        ConnectionModel connection = await dbContext.GetConnection(id);
        return new JsonResult(connection);
    }
}