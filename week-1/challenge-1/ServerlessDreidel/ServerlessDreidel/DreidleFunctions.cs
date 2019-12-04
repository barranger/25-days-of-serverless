using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ServerlessDreidel
{
    public class DreidleFunctions
    {
        private readonly string[] DREIDLE_SIDES = new string[] { "נ(Nun)", "ג(Gimmel)", "ה(Hay)", "ש(Shin)" };
        private Random random;

        public DreidleFunctions()
        {
            random = new Random();
        }

        [FunctionName("Dreidle")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            var index = this.random.Next(0, 3);
            var side = DREIDLE_SIDES[index];
            log.LogDebug("We are returning the side: {side}", side);
            return await Task.FromResult(new JsonResult(side));
                
        }
    }
}
