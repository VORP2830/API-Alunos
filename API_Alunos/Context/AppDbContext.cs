using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Aluno 01",
                    Email = "aluno01@escola.com.br",
                    Idade = 20
                },
                new Aluno
                {
                    Id= 2,
                    Nome = "Aluno 02",
                    Email = "aluno02@escola.com.br",
                    Idade = 22
                }
                );
        }
    }
}
