using CampeonatoAPI.Data.Context;
using CPEssoaAPI.Data.Repository;
using CPEssoaAPI.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CPEssoaAPI.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(
               options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PessoasDB;Trusted_Connection=True;MultipleActiveResultSets=true")
           );
        }
    }
}
