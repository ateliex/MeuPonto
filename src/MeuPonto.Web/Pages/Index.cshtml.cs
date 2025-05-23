using MeuPonto.Extensions;
using MeuPonto.Pages.Folhas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using MeuPonto.Models;

namespace MeuPonto.Pages;

[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly Data.MeuPontoDbContext _db;

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(Data.MeuPontoDbContext db, ILogger<IndexModel> logger)
    {
        _db = db;

        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    [DisplayName("Contrato")]
    public Guid? ContratoId { get; set; }

    [BindProperty(SupportsGet = true)]
    [DisplayName("CompetÍncia")]
    public DateTime? Competencia { get; set; }

    public Folha Folha { get; set; }

    public ApuracaoMensalViewModel ApuracaoMensal { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var contratosSelectList = new SelectList(_db.Contratos, "Id", "Nome");

        ViewData["ContratoId"] = contratosSelectList;

        ViewData["HasContrato"] = contratosSelectList.Any();

        ApuracaoMensal = new ApuracaoMensalViewModel();

        var hoje = DateTime.Today;

        if (Competencia == null)
        {
            Competencia = hoje;
        }
        else
        {
            var competencia = Competencia;

            Folha = await _db.Folhas.FirstOrDefaultAsync(x => true
                && x.ContratoId == ContratoId
                && x.Competencia == competencia);

            if (Folha != null)
            {
                var competenciaAtual = new DateTime(hoje.Year, hoje.Month, 1);

                var competenciaFolha = Folha.Competencia.Value;

                var competenciaFolhaPosterior = competenciaFolha.AddMonths(1);

                ApuracaoMensal = await _db.ApurarFolha(Folha, User, hoje, competenciaAtual, competenciaFolha, competenciaFolhaPosterior);
            }
        }

        return Page();
    }
}
