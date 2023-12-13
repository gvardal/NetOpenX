using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetOpenX.Rest.Client.Model.Enums;
using Rest.Library;

internal class Program
{
    private static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();


        ServiceProvider servives = new ServiceCollection()
            .AddSingleton(configuration)
            .AddTransient<IRestFunctions,RestFunctions>()
            .BuildServiceProvider();


        var restFunctions = servives.GetRequiredService<IRestFunctions>();
        var faturaOku = restFunctions.NetsisFaturaBilgileriOku(JTFaturaTip.ftSFat, "RDM202300000348", "120-001-001");



        Console.WriteLine("");
        Console.ReadLine();
    }
}