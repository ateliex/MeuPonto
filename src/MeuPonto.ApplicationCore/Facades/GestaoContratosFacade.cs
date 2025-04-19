using System.Transactions;
using MeuPonto.Models;

namespace MeuPonto.Facades;

public static class GestaoContratosFacade
{
    public static Contrato CriarContrato(this TransactionContext transaction, string nome, Guid? id = null)
    {
        var contrato = new Contrato(nome)
        {
            Id = id ?? Guid.NewGuid(),
            CreationDate = transaction.DateTime
        };

        //AdicionarJornadaTrabalhoSemanalPrevista(contrato, new TimeSpan(0, 0, 0), DayOfWeek.Sunday);
        //AdicionarJornadaTrabalhoSemanalPrevista(contrato, new TimeSpan(8, 0, 0), DayOfWeek.Monday);
        //AdicionarJornadaTrabalhoSemanalPrevista(contrato, new TimeSpan(8, 0, 0), DayOfWeek.Tuesday);
        //AdicionarJornadaTrabalhoSemanalPrevista(contrato, new TimeSpan(8, 0, 0), DayOfWeek.Wednesday);
        //AdicionarJornadaTrabalhoSemanalPrevista(contrato, new TimeSpan(8, 0, 0), DayOfWeek.Thursday);
        //AdicionarJornadaTrabalhoSemanalPrevista(contrato, new TimeSpan(8, 0, 0), DayOfWeek.Friday);
        //AdicionarJornadaTrabalhoSemanalPrevista(contrato, new TimeSpan(0, 0, 0), DayOfWeek.Saturday);

        return contrato;
    }

    //private static void AdicionarJornadaTrabalhoSemanalPrevista(Contrato contrato, TimeSpan tempo, DayOfWeek dayOfWeek)
    //{
    //    var jornadaTrabalhoDiaria = new JornadaTrabalhoDiaria
    //    {
    //        DiaSemana = dayOfWeek,
    //        Tempo = tempo
    //    };

    //    contrato.JornadaTrabalhoSemanalPrevista.Semana.Add(jornadaTrabalhoDiaria);
    //}

    public static Contrato AbrirContrato(this Contrato contrato, Empregador empregador)
    {
        contrato.Empregador = empregador;

        contrato.EmpregadorId = empregador?.Id;

        return contrato;
    }

    public static Contrato AlterarContrato(this Contrato contrato, Empregador empregador)
    {
        contrato.Empregador = empregador;

        contrato.EmpregadorId = empregador?.Id;

        return contrato;
    }

    public static void RecontextualizaContrato(this Contrato contrato, TransactionContext transaction, Guid? id = null)
    {
        contrato.Id = contrato.Id ?? id ?? Guid.NewGuid();
        contrato.CreationDate = transaction.DateTime;
    }
}
