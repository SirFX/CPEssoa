using CPEssoaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPEssoaAPI.Data.Mapping
{
    public class PessoaMap
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(20);
            builder.Property(x => x.SobreNome).HasMaxLength(30);
            builder.Property(x => x.Cpf).HasMaxLength(20);
            builder.Property(x => x.Telefone).HasMaxLength(20);
        }
    }
}
