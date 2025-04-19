using MeuPonto.Data;
using MeuPonto.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeuPonto.Models;
using MeuPonto.Facades;

namespace MeuPonto.Pages.Pontos;

public class MarcarModel : FormPageModel
{
    private readonly MeuPontoDbContext _db;

    private readonly DateTimeSnapshot _dateTimeSnapshot;

    [BindProperty]
    public Ponto Ponto { get; set; }

    public MarcarModel(
        MeuPontoDbContext db,
        DateTimeSnapshot dateTimeSnapshot)
    {
        _db = db;

        _dateTimeSnapshot = dateTimeSnapshot;
    }

    public IActionResult OnGet()
    {
        var transaction = User.CreateTransaction();

        Ponto = RegistroPontosFacade.CriaPonto(transaction);

        Ponto.DataHora = _dateTimeSnapshot.GetDateTimeUntilMinutes();

        ViewData["ContratoId"] = new SelectList(_db.Contratos.Where(x => x.Ativo), "Id", "Nome");

        HoldRefererUrl();

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        var transaction = User.CreateTransaction();

        if (!ModelState.IsValid)
        {
            ViewData["ContratoId"] = new SelectList(_db.Contratos.Where(x => x.Ativo), "Id", "Nome");

            return Page();
        }

        Ponto.RecontextualizaPonto(transaction);

        var contrato = await _db.Contratos.FindByIdAsync(Ponto.ContratoId);

        contrato.QualificaPonto(Ponto);

        _db.Pontos.Add(Ponto);

        await _db.SaveChangesAsync();

        var detalharPage = Url.Page("Detalhar", new { id = Ponto.Id });

        AddTempSuccessMessageWithDetailLink("Ponto marcado com sucesso", detalharPage);

        if (ShouldRedirectToRefererPage())
        {
            return RedirectToRefererPage();
        }
        else
        {
            return Redirect(detalharPage);
        }
    }
}
