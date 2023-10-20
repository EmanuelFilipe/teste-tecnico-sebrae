using ConsultaCep.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
        }

        // configuração para usar o projeto de Testes
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Conta> Contas { get; set; }
    }
}
