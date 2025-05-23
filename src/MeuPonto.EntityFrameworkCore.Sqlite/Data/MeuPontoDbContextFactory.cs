﻿using MeuPonto.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeuPonto.Data;

internal class MeuPontoDbContextFactory : IDesignTimeDbContextFactory<MeuPontoDbContext>
{
    public MeuPontoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MeuPontoDbContext>();

        optionsBuilder
            .UseSqlite("Data Source={dataSource}")
            .UseSqliteModel();

        return new MeuPontoDbContext(optionsBuilder.Options);
    }
}
