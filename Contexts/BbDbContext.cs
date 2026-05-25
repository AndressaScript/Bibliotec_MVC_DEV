
using Bibliotec_MVC_DEV.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec_MVC_DEV.Contexts
{
    public class BbDbContext : DbContext
    {
        public BbDbContext(DbContextOptions<BbDbContext> options) : base (options){}
        
            public  DbSet<Usuario> Usuario { get; set; }  = null!;

            public  DbSet<Categoria> Categoria { get; set; }  = null!;

            public  DbSet<Livro> Livro { get; set; }  = null!;

            public  DbSet<LivroCategoria> LivroCategoria { get; set; }  = null!;

            public  DbSet<Reserva> Reserva { get; set; }  = null!;

        //nesse caso como LivroCategoria possui apenas Fks, realizamos essa configuração
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroCategoria>()
                .HasKey(lc => new{lc.LivroId, lc.CategoriaId}); //conf qual será a chave primária dessa entidade, nesse caso a junção de livroId e categoriaId
        }
        
    }
}