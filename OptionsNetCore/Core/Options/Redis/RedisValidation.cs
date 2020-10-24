using Microsoft.Extensions.Options;

namespace OptionsNetCore.Core.Options.Redis
{
    public class RedisValidation : IValidateOptions<RedisOptions>
    {
        public ValidateOptionsResult Validate(string name, RedisOptions options)
        {
            string failures = null;

            if (options.ConnectRetry > 3 && options.ConnectTimeout <= 5000)
                failures = "ConnectTimeout must be > than 5000";

            if (!string.IsNullOrEmpty(failures))
                return ValidateOptionsResult.Fail(failures);

            return ValidateOptionsResult.Success;
        }
    }
}
