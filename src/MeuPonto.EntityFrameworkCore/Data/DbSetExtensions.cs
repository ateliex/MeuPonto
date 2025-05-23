﻿using MeuPonto.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuPonto.Data;

public static class DbSetExtensions
{
    public static ValueTask<TEntity?> FindByIdAsync<TEntity>(this DbSet<TEntity> dbSet, Guid? id, string partitionKey) where TEntity : class
    {
        return dbSet.FindAsync(id);
    }

    public static ValueTask<Empregador> FindByIdAsync(this DbSet<Empregador> dbSet, Guid? id)
    {
        return dbSet.FindAsync(id);
    }

    public static ValueTask<Contrato> FindByIdAsync(this DbSet<Contrato> dbSet, Guid? id)
    {
        return dbSet.FindAsync(id);
    }

    public static ValueTask<Ponto> FindByIdAsync(this DbSet<Ponto> dbSet, Guid? id, int ano)
    {
        var partitionKey = $"{ano}";

        return dbSet.FindAsync(id);
    }

    public static string HandleException(this Exception ex)
    {
        if (ex.InnerException is Exception sqlException)
        {
            if (sqlException.Message.Contains("Request size is too large"))
            {
                return "Request size is too large";
            }

            return sqlException.Message;
        }

        return ex.Message;
    }
}
