using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace bank_account_management_api.Models
{
    [Table("transfers")]
    public class Transacao
    {
        public Transacao(int contaorigemid, int contadestinoid, decimal valor, DateTime datatransacao)
        {
            this.contaorigemid = contaorigemid;
            this.contadestinoid = contadestinoid;
            this.valor = valor;
            this.datatransacao = datatransacao;
        }

        [Key]
        public int id { get; set; }
        public int contaorigemid { get; set; }
        public int contadestinoid { get; set; }
        public decimal valor { get; set; }
        public DateTime datatransacao { get; set; }
    }
}