using System.Transactions;
using MeuPonto.Models;

namespace MeuPonto.Facades;

public static class BackupComprovantesFacade
{
    public static Comprovante CriaComprovante(TransactionContext transaction, Guid? id = null)
    {
        var comprovante = new Comprovante
        {
            Id = id ?? Guid.NewGuid(),
            CreationDate = transaction.DateTime
        };

        return comprovante;
    }

    public static void RecontextualizaComprovante(this Comprovante comprovante, TransactionContext transaction, Guid? id = null)
    {
        comprovante.Id = comprovante.Id ?? id ?? Guid.NewGuid();
        comprovante.CreationDate = transaction.DateTime;
    }
}
