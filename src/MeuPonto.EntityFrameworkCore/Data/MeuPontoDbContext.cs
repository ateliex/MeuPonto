using MeuPonto.Models;
using MeuPonto.Models.Contratos;
using MeuPonto.Models.Pontos;
using Microsoft.EntityFrameworkCore;
using MeuPonto.Models.Folhas;

namespace MeuPonto.Data;

public class MeuPontoDbContext : DbContext
{
    public MeuPontoDbContext()
    {

    }

    public MeuPontoDbContext(DbContextOptions<MeuPontoDbContext> options)
        : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    var dataSource = "C:\\temp\\MeuPonto.db";

    //    optionsBuilder.UseSqlite($"Data Source={dataSource}");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Configuracoes> Configuracoes { get; set; }
    public DbSet<Empregador> Empregadores { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Ponto> Pontos { get; set; }
    public DbSet<Comprovante> Comprovantes { get; set; }
    public DbSet<Folha> Folhas { get; set; }
}
