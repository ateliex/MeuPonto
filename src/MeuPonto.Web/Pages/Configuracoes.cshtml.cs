using MeuPonto.Data;
using MeuPonto.Helpers;
using MeuPonto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace MeuPonto.Pages;

public class ConfiguracoesModel : PageModel
{
    private readonly MeuPontoDbContext _db;

    private readonly IMemoryCache _cache;

    private readonly ILogger<ConfiguracoesModel> _logger;

    public bool ResetSuccess { get; set; }

    [BindProperty]
    public string AskConfirmation { get; set; }

    [BindProperty]
    public bool JavascriptIsEnabled { get; set; }

    public bool AskResetConfirmation { get; set; }

    [BindProperty]
    public Configuracoes Configuracoes { get; set; } = default!;

    public ConfiguracoesModel(
        MeuPontoDbContext db,
        IMemoryCache cache,
        ILogger<ConfiguracoesModel> logger)
    {
        _db = db;

        _cache = cache;

        _logger = logger;
    }

    public async Task<IActionResult> OnGet(string? id)
    {
        ResetSuccess = false;

        if (id != null)
        {
            return Forbid();
        }

        Configuracoes = await _db.Configuracoes.FirstOrDefaultAsync();

        if (Configuracoes == null)
        {
            Configuracoes = new Configuracoes
            {
                
            };
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string? id, string command)
    {
        if (AskConfirmation == "Reset 2")
        {
            AskResetConfirmation = true;

            ViewData.ShowModal(true);
        }

        if (command == "Reset")
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            _cache.Remove("JavascriptIsEnabled");

            ResetSuccess = true;
        }

        if (id != null)
        {
            return Forbid();
        }

        Configuracoes = await _db.Configuracoes.FirstOrDefaultAsync();

        if (Configuracoes == null)
        {
            Configuracoes = new Configuracoes
            {
                JavascriptIsEnabled = JavascriptIsEnabled
            };

            _db.Configuracoes.Add(Configuracoes);
        }

        if (JavascriptIsEnabled)
        {
            Configuracoes.JavascriptIsEnabled = true;
        }
        else
        {
            Configuracoes.JavascriptIsEnabled = false;
        }

        try
        {
            await _db.SaveChangesAsync();

            _cache.Set("JavascriptIsEnabled", JavascriptIsEnabled);

            HttpContext.JavascriptIsEnabled(JavascriptIsEnabled);
        }
        catch (Exception _)
        {
            throw;
        }

        return Page();
    }
}