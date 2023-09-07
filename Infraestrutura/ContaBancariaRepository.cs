using System;
using bank_account_management_api.Models;

namespace bank_account_management_api.Infraestrutura
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(ContaBancaria conta)
        {
            _context.ContasBancarias.Add(conta);
            _context.SaveChanges();
        }

        public List<ContaBancaria> Get()
        {
            return _context.ContasBancarias.ToList();
        }

        public ContaBancaria GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ContaBancaria GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ContaBancaria ObterPorEmailSenha(string email, string senha)
        {
            return _context.ContasBancarias.FirstOrDefault(c => c.email == email && c.senha == senha);
        }

        public void Update(ContaBancaria conta)
        {
            throw new NotImplementedException();
        }

        public decimal GetSaldo(int id)
        {
            var conta = _context.ContasBancarias.FirstOrDefault(c => c.id == id);
            return conta != null ? conta.saldo : 0.0m; // Retorna o saldo ou 0 se a conta não for encontrada
        }
    }
}

