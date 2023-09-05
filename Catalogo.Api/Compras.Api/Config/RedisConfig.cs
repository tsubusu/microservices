namespace Compras.Api.Config
{
    public static class RedisConfig
    {
        public static void ConfigurarRedis(IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
            });
        }
    }
}
