namespace OptionsNetCore.Core.Options.Redis
{
    /// <summary>
    /// Class that contains the options to configure Redis in the Microservice
    /// </summary>
    public class ClientRedisBase
    {
        /// <summary>
        /// Default database index, from 0 to databases - 1
        /// </summary>
        public int DefaultDatabase { get; set; }
        /// <summary>
        /// Optional channel prefix for all pub/sub operations
        /// </summary>
        public string ChannelPrefix { get; set; }
        /// <summary>
        /// Identification for the connection within redis
        /// </summary>
        public string ClientName { get; set; }
    }
}
