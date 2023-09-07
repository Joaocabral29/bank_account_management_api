using System;

namespace bank_account_management_api.Models
{
	public interface ITransacaoRepository
    {
        void RealizarTransferencia(int contaOrigemId, int contaDestinoId, decimal valor);

        List<Transacao> ObterExtrato(int contaId);
    }
}

