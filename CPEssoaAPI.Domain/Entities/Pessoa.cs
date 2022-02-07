namespace CPEssoaAPI.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; } 
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }
}
