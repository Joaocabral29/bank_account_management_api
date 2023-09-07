using System;
using bank_account_management_api.Models;

namespace bank_account_management_api.Infraestrutura
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void RealizarTransferencia(int contaOrigemId, int contaDestinoId, decimal valor)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var contaOrigem = _context.ContasBancarias.FirstOrDefault(c => c.id == contaOrigemId);
                    var contaDestino = _context.ContasBancarias.FirstOrDefault(c => c.id == contaDestinoId);

                    if (contaOrigem == null || contaDestino == null)
                    {
                        throw new Exception("Conta de origem ou destino não encontrada.");
                    }

                    if (contaOrigem.saldo < valor)
                    {
                        throw new Exception("Saldo insuficiente na conta de origem.");
                    }

                    // Atualize os saldos das contas
                    contaOrigem.saldo -= valor;
                    contaDestino.saldo += valor;

                    // Crie um registro de transferência com os argumentos necessários
                    var transferencia = new Transacao(contaOrigemId, contaDestinoId, valor, DateTime.UtcNow);

                    // Adicione a transferência ao contexto
                    _context.Transacoes.Add(transferencia);

                    // Salve as mudanças no banco de dados
                    _context.SaveChanges();

                    // Commit da transação
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback da transação em caso de erro
                    transaction.Rollback();
                    throw ex;
                }
            }
        }


        public List<Transacao> ObterExtrato(int contaId)
        {
            return _context.Transacoes
                .Where(t => t.contaorigemid == contaId || t.contadestinoid == contaId)
                .OrderByDescending(t => t.datatransacao)
                .ToList();
        }
    }
}

