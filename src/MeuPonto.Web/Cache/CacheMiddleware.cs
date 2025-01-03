﻿using MeuPonto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace MeuPonto.Cache;

public class CacheMiddleware
{
    private readonly RequestDelegate _next;

    private readonly IMemoryCache _cache;

    public CacheMiddleware(
        RequestDelegate next,
        IMemoryCache cache)
    {
        _next = next;

        _cache = cache;
    }

    public async Task Invoke(
        HttpContext context,
        MeuPontoDbContext db,
        ILogger<CacheMiddleware> logger)
    {
        var javascriptIsEnabled = await _cache.GetOrCreateAsync("JavascriptIsEnabled", async entry =>
        {
            var configuracoes = await db.Configuracoes.FirstOrDefaultAsync();

            if (configuracoes == null)
            {
                return true;
            }
            else
            {
                return configuracoes.JavascriptIsEnabled;
            }
        });

        context.Items.Add("JavascriptIsEnabled", javascriptIsEnabled);

        await _next(context);
    }
}
