namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration((hostingContext, configBuilder) =>
                {
                    configBuilder.AddEnvironmentVariables(prefix: "BO_");
                    configBuilder.AddEnvironmentVariables(prefix: "BO_DIGITAIS_");
                    var config = configBuilder.Build();
                });
    }
}