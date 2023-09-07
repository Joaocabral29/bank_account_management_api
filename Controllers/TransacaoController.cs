using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank_account_management_api.Infraestrutura;
using bank_account_management_api.Models;
using bank_account_management_api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace bank_account_management_api.Controllers
{
    [Route("api/Trasacao")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoRepository? _transacaoRepository;

        public TransacaoController(ITransacaoRepository? transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        [HttpPost("transferencia")]
        public IActionResult RealizarTransferencia(TransacaoViewModel transacaoModel)
        {
            // Valide os dados da transferência, verifique se as contas existem, etc.
            // Chame o método de transferência no seu repositório

            _transacaoRepository.RealizarTransferencia(
                transacaoModel.ContaOrigemId,
                transacaoModel.ContaDestinoId,
                transacaoModel.Valor);

            return Ok("Transferência realizada com sucesso");
        }

        [HttpGet("extrato/{contaId}")]
        public IActionResult ObterExtrato(int contaId)
        {
            var extrato = _transacaoRepository.ObterExtrato(contaId);
            return Ok(extrato);
        }
    }
}