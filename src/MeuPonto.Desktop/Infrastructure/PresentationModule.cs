using MeuPonto.Windows.Contratos;
using MeuPonto.Windows.Folhas;
using MeuPonto.Windows.Pontos;
using Microsoft.Extensions.DependencyInjection;

namespace MeuPonto.Infrastructure;

public static class PresentationModule
{
    public static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.AddTransient(typeof(MainWindow));

        services.AddTransient(typeof(CadastroEmpregadoresWindow));

        services.AddTransient(typeof(GestaoContratosWindow));

        services.AddTransient(typeof(RegistroPontosWindow));

        services.AddTransient(typeof(BackupComprovantesWindow));

        services.AddTransient(typeof(GestaoFolhasWindow));

        return services;
    }
}
