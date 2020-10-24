using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionsNetCore.Core.Options.Redis;
using System.Threading.Tasks;

namespace MiddlewareLifetimes.Middlewares
{
    /// <summary>
    /// Custom Middleware que mostrara por primera vez el id de la operación del servicio operation scoped
    /// </summary>
    public class Options2Middlware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<Options2Middlware> logger;

        private readonly IOptions<RedisOptions> options;

        /// <summary>
        /// Crea una nueva instancia de CustomMiddleware
        /// </summary>
        /// <param name="next">A function that can process an HTTP request.</param>
        public Options2Middlware(RequestDelegate next, ILogger<Options2Middlware> logger, IOptions<RedisOptions> options)
        {
            this._next = next;
            this.logger = logger;
            this.options = options;
        }

        /// <summary>
        /// Representing the remaining middleware in the request pipeline.
        /// </summary>
        /// <param name="context">Encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <param name="options">Snapshot de las configuraciones en el inicio de la petición</param>
        /// <returns>Represents an asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context, IOptionsSnapshot<RedisOptions> optionsSnapshot)
        {
            var snapshot = Newtonsoft.Json.JsonConvert.SerializeObject(optionsSnapshot.Value, Newtonsoft.Json.Formatting.Indented);

            this.logger.LogInformation("Options Snapshot -------------------------------------------");
            this.logger.LogInformation(snapshot);

            var options = Newtonsoft.Json.JsonConvert.SerializeObject(this.options.Value, Newtonsoft.Json.Formatting.Indented);

            this.logger.LogInformation("Options Monitor -------------------------------------------");
            this.logger.LogInformation(options);

            await _next(context);
        }
    }
}
