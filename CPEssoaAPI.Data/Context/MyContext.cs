using CPEssoaAPI.Data.Mapping;
using CPEssoaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoAPI.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) {}
        public DbSet<Pessoa> Pessoas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(new PessoaMap().Configure);
            base.OnModelCreating(modelBuilder);
        }        
    }
}
