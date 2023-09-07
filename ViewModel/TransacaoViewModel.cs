using System;
namespace bank_account_management_api.ViewModel
{
    public class TransacaoViewModel
    {
        public int ContaOrigemId { get; set; }
        public int ContaDestinoId { get; set; }
        public decimal Valor { get; set; }
    }
}

