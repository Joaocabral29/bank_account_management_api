using System;
using System.ComponentModel.DataAnnotations;

namespace bank_account_management_api.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

