using MeuPonto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MeuPonto.Data;

/// <summary>
/// https://stackoverflow.com/questions/69601431/how-can-i-intercept-the-modelbuilder-instance-in-a-dbcontext
/// </summary>
public class SqliteModelCustomizer : RelationalModelCustomizer
{
    public SqliteModelCustomizer(ModelCustomizerDependencies dependencies)
        : base(dependencies)
    {
        
    }

    public override void Customize(ModelBuilder modelBuilder, DbContext context)
    {
        base.Customize(modelBuilder, context);
    }
}
