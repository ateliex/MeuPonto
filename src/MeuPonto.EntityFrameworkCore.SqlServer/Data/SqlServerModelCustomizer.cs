using MeuPonto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MeuPonto.Data;

/// <summary>
/// https://stackoverflow.com/questions/69601431/how-can-i-intercept-the-modelbuilder-instance-in-a-dbcontext
/// </summary>
public class SqlServerModelCustomizer : RelationalModelCustomizer
{
    public SqlServerModelCustomizer(ModelCustomizerDependencies dependencies)
        : base(dependencies)
    {

    }

    public override void Customize(ModelBuilder modelBuilder, DbContext context)
    {
        base.Customize(modelBuilder, context);

        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.Entity<Empregador>().Property(b => b.CreationDate).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Contrato>().Property(b => b.CreationDate).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Ponto>().Property(b => b.CreationDate).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Comprovante>().Property(b => b.CreationDate).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Folha>().Property(b => b.CreationDate).HasDefaultValueSql("getdate()");
    }
}
