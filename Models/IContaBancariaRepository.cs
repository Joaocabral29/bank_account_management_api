using System;

namespace bank_account_management_api.Models
{
	public interface IContaBancariaRepository
    {
        ContaBancaria GetById(int id);

        ContaBancaria GetByEmail(string email);

        ContaBancaria ObterPorEmailSenha(string email, string senha);

        void Add(ContaBancaria conta);

        void Update(ContaBancaria conta);

        public List<ContaBancaria> Get();

        public decimal GetSaldo(int id);
    }
}

