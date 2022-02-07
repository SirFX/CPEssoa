using CPEssoaAPI.Domain.Interfaces.Services;
using CPEssoaAPI.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CPEssoaAPI.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPessoaService, PessoaService>();
        }
    }
}
