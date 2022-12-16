
using DIFunction.Interface;
using DIFunction.Template;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace DIFunction
{
    public class QuoteFunction
    {
        private readonly IQuoteBank _repository;

        public QuoteFunction(IQuoteBank repository)
        {
            _repository = repository;
        }

        [FunctionName("GetQuote")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            Quote quote = _repository.getQuote();
            return new OkObjectResult(quote);
        }
    }
}
