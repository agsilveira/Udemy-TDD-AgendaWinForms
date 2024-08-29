using Microsoft.Extensions.Configuration;

public class AppSettingsTests
{
    private readonly IConfiguration _configuration;

    public AppSettingsTests()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Define o caminho base para o arquivo JSON
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Adiciona o arquivo JSON

        _configuration = builder.Build();
    }

    public string GetConnectionString(string name)
    {
        var connectionSection = _configuration.GetSection($"ConnectionStrings:{name}");
        return connectionSection["ConnectionString"];
    }

    public string GetProviderName(string name)
    {
        var connectionSection = _configuration.GetSection($"ConnectionStrings:{name}");
        return connectionSection["ProviderName"];
    }
}