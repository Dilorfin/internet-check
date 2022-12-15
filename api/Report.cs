using api.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace api;

public static class Report
{
    [FunctionName("Report")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        var dbContext = new DatabaseContext(connectionString);

        string id = req.Query["id"];
        await dbContext.ReportConnectionRequestTime(id, DateTime.Now);

        return new OkResult();
    }
}