using MeuPonto.Extensions;
using MeuPonto.Pages.Folhas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace MeuPonto.Pages.Folhas;

public class RelatorioModel : PageModel
{
    private readonly Data.MeuPontoDbContext _db;

    public RelatorioModel(Data.MeuPontoDbContext db)
    {
        _db = db;
    }

    [BindProperty(SupportsGet = true)]
    [DisplayName("Contrato")]
    public Guid? ContratoId { get; set; }

    [BindProperty(SupportsGet = true)]
    [DisplayName("Nome Contrato")]
    public string? ContratoNome { get; set; }

    [BindProperty(SupportsGet = true)]
    [DisplayName("Contrato Ativo")]
    public bool ContratoAtivo { get; set; } = true;

    [BindProperty(SupportsGet = true)]
    [DisplayName("Competência")]
    public DateTime? Competencia { get; set; }

    public ApuracaoMensalViewModel ApuracaoMensal { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var contratosSelectList = new SelectList(_db.Contratos, "Id", "Nome");

        ViewData["ContratoId"] = contratosSelectList;

        ViewData["HasContrato"] = contratosSelectList.Any();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var hoje = DateTime.Today;

        if (ContratoId == null)
        {
            var contratoPadrao = await _db.Contratos.FirstOrDefaultAsync(x => true);

            ContratoId = contratoPadrao?.Id;
        }

        if (ContratoId != null)
        {
            var contrato = await _db.Contratos.FirstOrDefaultAsync(x => true
                && x.Id == ContratoId);

            ContratoNome = contrato?.Nome;
        }

        if (Competencia == null)
        {
            var competenciaPadrao = new DateTime(hoje.Year, hoje.Month, 1);

            Competencia = competenciaPadrao;
        }

        var folha = await _db.Folhas.FirstOrDefaultAsync(x => true
            && x.ContratoId == ContratoId
            && x.Competencia == Competencia);

        if (folha == null)
        {
            ApuracaoMensal = new ApuracaoMensalViewModel();
        }
        else
        {
            var competenciaAtual = new DateTime(hoje.Year, hoje.Month, 1);

            var competenciaFolha = folha.Competencia.Value;

            var competenciaFolhaPosterior = competenciaFolha.AddMonths(1);

            ApuracaoMensal = await _db.ApurarFolha(folha, User, hoje, competenciaAtual, competenciaFolha, competenciaFolhaPosterior);
        }

        return Page();
    }
}
