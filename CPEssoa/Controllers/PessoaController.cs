using AutoMapper;
using CPEssoaAPI.Domain.Entities;
using CPEssoaAPI.Domain.Interfaces.Services;
using CPEssoaAPI.Domain.Parameters;
using CPEssoaAPI.ViewModel;
using CPEssoaAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CPEssoaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IPessoaService pessoaService;
        private readonly IMapper mapper;

        public PessoaController(
            IPessoaService pessoaService,
            IMapper mapper)
        {
            this.pessoaService = pessoaService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametersPage pageParameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var pessoas = await this.pessoaService.GetPessoas(pageParameters);

                var pessoasViewModel = this.mapper.Map<List<Pessoa>, List<PessoaViewModel>>(pessoas);
                var result = new PessoaPageViewModel();
                var qtdPagina = await this.pessoaService.Count();
                qtdPagina = qtdPagina / pageParameters.PageSize + 1;

                result.Pessoas = pessoasViewModel;
                result.TamanhoPagina = pageParameters.PageSize;
                result.QtdPagina = qtdPagina;
                result.Pagina = pageParameters.PageSize;

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetPessoa")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await this.pessoaService.Get(id);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPessoaViewModel addPessoaViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            { 
                var pessoa = new Pessoa
                {
                    Nome = addPessoaViewModel.Nome,
                    SobreNome = addPessoaViewModel.Sobrenome,
                    Cpf = addPessoaViewModel.Cpf,
                    Telefone = addPessoaViewModel.Telefone,
                };
                var result = await this.pessoaService.Post(pessoa);
                if (result != null)
                {
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AddPessoaViewModel addPessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var pessoa = new Pessoa
                {
                    Nome = addPessoaViewModel.Nome,
                    SobreNome = addPessoaViewModel.Sobrenome,
                    Cpf = addPessoaViewModel.Cpf,
                    Telefone = addPessoaViewModel.Telefone,
                };
                pessoa.Id = id;
                var result = await this.pessoaService.Put(pessoa);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Pessoa não existe!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await this.pessoaService.Delete(id);

                if (result == false)
                {
                    return BadRequest("Pessoa não encontrada");
                }
                else
                {
                    return Ok("Excluído com sucesso");
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
