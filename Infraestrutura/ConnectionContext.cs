using System;
using bank_account_management_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bank_account_management_api.Infraestrutura
{
	public class ConnectionContext : DbContext
	{
		public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;Database=bank_account_management;"+
            "User Id=postgres;"+
            "Password=2323;");
    }
}

