using MeuPonto.Windows.Contratos;
using MeuPonto.Windows.Folhas;
using MeuPonto.Windows.Pontos;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MeuPonto;

public partial class MainWindow : Window
{
    public IServiceProvider ServiceProvider { get; }

    public MainWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        ServiceProvider = serviceProvider;
    }

    private void CadastroEmpregadoresMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var cadastroEmpregadoresWindow = ServiceProvider.GetRequiredService<CadastroEmpregadoresWindow>();

        cadastroEmpregadoresWindow.Show();
    }

    private void GestaoContratosMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var gestaoContratosWindow = ServiceProvider.GetRequiredService<GestaoContratosWindow>();

        gestaoContratosWindow.Show();
    }

    private void RegistroPontosMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var registroPontosForm = ServiceProvider.GetRequiredService<RegistroPontosWindow>();

        registroPontosForm.Show();
    }

    private void GestaoFolhasMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var gestaoFolhasForm = ServiceProvider.GetRequiredService<GestaoFolhasWindow>();

        gestaoFolhasForm.Show();
    }

    private void BackupComprovantesMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var backupComprovantesForm = ServiceProvider.GetRequiredService<BackupComprovantesWindow>();

        backupComprovantesForm.Show();
    }

    private void configuracoesMenuItem_Click(object sender, RoutedEventArgs e)
    {

    }
}
