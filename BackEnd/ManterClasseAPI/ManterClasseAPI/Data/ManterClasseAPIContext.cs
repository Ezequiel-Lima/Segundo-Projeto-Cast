using ManterClasseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManterClasseAPI.Data
{
    public class ManterClasseAPIContext : DbContext
    {
        public ManterClasseAPIContext(DbContextOptions<ManterClasseAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ClasseObjeto> ClasseObjeto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClasseObjeto>().HasData(
                new ClasseObjeto { Id = 1, Descricao = "entidade (Empresa, órgão)", Ativo = true },
                new ClasseObjeto { Id = 2, Descricao = "departamento", Ativo = true },
                new ClasseObjeto { Id = 3, Descricao = "obra", Ativo = true },
                new ClasseObjeto { Id = 4, Descricao = "serviços", Ativo = true },
                new ClasseObjeto { Id = 5, Descricao = "processo", Ativo = true },
                new ClasseObjeto { Id = 6, Descricao = "política pública", Ativo = true },
                new ClasseObjeto { Id = 7, Descricao = "sistema de informações", Ativo = true },
                new ClasseObjeto { Id = 8, Descricao = "procedimento", Ativo = true },
                new ClasseObjeto { Id = 9, Descricao = "controle", Ativo = true },
                new ClasseObjeto { Id = 10, Descricao = "demonstrativo", Ativo = true },
                new ClasseObjeto { Id = 11, Descricao = "itens de orçamento", Ativo = true },
                new ClasseObjeto { Id = 12, Descricao = "normativo", Ativo = true },
                new ClasseObjeto { Id = 13, Descricao = "folha de pagamento", Ativo = true }
            );
        }
    }
}
