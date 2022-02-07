using CPEssoaAPI.Domain.Entities;
using CPEssoaAPI.Domain.Interfaces.Repository;
using CPEssoaAPI.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CPEssoaAPI.Test.Services
{
    public class PessoaServiceTests
    {
        [Fact]
        public void PessoaService_GetAll_DeveRetornarPessoas()
        {
            //Arrange
            var pessoa = new Pessoa
            {
                Nome = "TesteNome",
                SobreNome = "TesteSobrenome",
                Cpf = "00001111000",
                Telefone = "69696969"
            };

            var pessoas = new List<Pessoa>
            { 
                pessoa
            };

            var repository = Substitute.For<IRepository<Pessoa>>();

            repository.SelectAsync().ReturnsForAnyArgs(pessoas);

            //Act

            var pessoaService = new PessoaService(repository);

            var pessoasRetornadas = pessoaService.GetAll().Result.ToList();

            //Asserts

            Assert.Equal(pessoa.Nome, pessoasRetornadas[0].Nome);
            Assert.Equal(pessoa.SobreNome, pessoasRetornadas[0].SobreNome);
            Assert.Equal(pessoa.Cpf, pessoasRetornadas[0].Cpf);
            Assert.Equal(pessoa.Telefone, pessoasRetornadas[0].Telefone);
        }
    }
}
