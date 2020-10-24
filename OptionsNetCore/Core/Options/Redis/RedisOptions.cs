using System.ComponentModel.DataAnnotations;

namespace OptionsNetCore.Core.Options.Redis
{
    public class RedisOptions
    {
        public const string Redis = "RedisSettings";

        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ConnectRetry { get; set; }


        [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ConnectTimeout { get; set; }


        [Range(0, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int SyncTimeout { get; set; }


        [Required]
        public string Password { get; set; }


        [Required]
        [RegularExpression("([0-9.]+)(:)+([0-9]{2,4})")]
        public string EndPoints { get; set; }


        [Required]
        public string ServiceName { get; set; }

        [Required]
        public string InstanceName { get; set; }

        public bool ResolveDns { get; set; }
        public bool Ssl { get; set; }
    }
}
