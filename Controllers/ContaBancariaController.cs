using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank_account_management_api.Models;
using bank_account_management_api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace bank_account_management_api.Controllers
{
    [Route("api/contabancaria")]
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        private readonly IContaBancariaRepository? _contaRepository;

        public ContaBancariaController(IContaBancariaRepository? contaRepository)
        {
            _contaRepository = contaRepository;
        }

        [HttpPost]
        public IActionResult Add(ContaBancariaViewModel contaBancariaView)
        {
            var contabancaria = new ContaBancaria(
                contaBancariaView.Nome,
                contaBancariaView.Email,
                contaBancariaView.Senha,
                contaBancariaView.Saldo);

            _contaRepository.Add(contabancaria);

            return Ok("Conta cadastrada com sucesso!");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel loginModel)
        {
            // Verifique se o e-mail e a senha correspondem a uma conta no banco de dados
            var conta = _contaRepository.ObterPorEmailSenha(loginModel.Email, loginModel.Senha);

            if (conta == null)
            {
                // Caso não encontre a conta, retorne um erro ou mensagem de autenticação inválida
                return BadRequest("Credenciais inválidas");
            }

            // Autenticação bem-sucedida; você pode gerar um token de autenticação JWT ou retornar outros dados relevantes aqui
            // Exemplo: var token = GerarToken(conta);

            return Ok("Autenticação bem-sucedida");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contabancaria = _contaRepository.Get();

            return Ok(contabancaria);
        }

        [HttpGet("{id}/saldo")]
        public IActionResult GetSaldo(int id)
        {
            var saldo = _contaRepository.GetSaldo(id);

            if (saldo < 0)
            {
                return NotFound("Conta não encontrada.");
            }

            return Ok($"Saldo da conta: {saldo}");
        }
    }
}