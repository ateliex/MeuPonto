using System.Transactions;
using MeuPonto.Models;

namespace MeuPonto.Facades;

public static class CadastroEmpregadoresFacade
{
    public static Empregador CriaEmpregador(this TransactionContext transaction, Guid? id = null)
    {
        var empregador = new Empregador
        {
            Id = id ?? Guid.NewGuid(),
            CreationDate = transaction.DateTime
        };

        return empregador;
    }

    public static void RecontextualizaEmpregador(this Empregador empregador, TransactionContext transaction, Guid? id = null)
    {
        empregador.Id = empregador.Id ?? id ?? Guid.NewGuid();
        empregador.CreationDate = transaction.DateTime;
    }
}
