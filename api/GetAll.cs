using api.db;
using api.db.models;
using api.dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api;

public static class GetAll
{
    [FunctionName("GetAll")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        var dbContext = new DatabaseContext(connectionString);
        
        IEnumerable<ConnectionModel> list = await dbContext.GetAllConnections();
        var result = list.Select(item => new ConnectionDto(item.title, item.lastRequestTime))
            .ToArray();

        return new JsonResult(result);
    }
}