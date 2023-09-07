using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bank_account_management_api.Models
{
    [Table("accounts")]
    public class ContaBancaria
    {
        public ContaBancaria(string nome, string email, string senha, decimal saldo)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.numeroconta = GerarNumeroContaAleatorio();
            this.saldo = saldo;
        }

        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string numeroconta { get; set; }
        public decimal saldo { get; set; }

        private string GerarNumeroContaAleatorio()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        }
}
