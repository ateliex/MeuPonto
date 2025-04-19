using MeuPonto.Data;
using MeuPonto.Extensions;
using MeuPonto.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeuPonto.Models;
using MeuPonto.Facades;

namespace MeuPonto.Pages.Contratos;

public class CriarModel : FormPageModel
{
    private readonly MeuPontoDbContext _db;

    [BindProperty]
    public Contrato AberturaContrato { get; set; }

    public CriarModel(MeuPontoDbContext db)
    {
        _db = db;
    }

    public IActionResult OnGet()
    {
        var transaction = User.CreateTransaction();

        AberturaContrato = GestaoContratosFacade.CriarContrato(transaction, null);

        ViewData["EmpregadorId"] = new SelectList(_db.Empregadores, "Id", "Nome").AddEmptyValue();

        HoldRefererUrl();

        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        var transaction = User.CreateTransaction();

        AberturaContrato.RecontextualizaContrato(transaction);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        Empregador empregador;

        if (AberturaContrato.EmpregadorId != null)
        {
            empregador = await _db.Empregadores.FindByIdAsync(AberturaContrato.EmpregadorId);
        }
        else
        {
            empregador = null;
        }

        var contrato = AberturaContrato.AbrirContrato(empregador);

        _db.Contratos.Add(contrato);

        await _db.SaveChangesAsync();

        var detalharPage = Url.Page("Detalhar", new { id = AberturaContrato.Id });

        AddTempSuccessMessageWithDetailLink("Contrato criado com sucesso", detalharPage);

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
