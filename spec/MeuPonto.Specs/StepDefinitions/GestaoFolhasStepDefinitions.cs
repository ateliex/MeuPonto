using MeuPonto.Data;
using MeuPonto.Drivers;
using MeuPonto.Support;
using System.Transactions;
using MeuPonto.Facades;
using MeuPonto.Models;
using System.Security.Claims;
using MeuPonto.Extensions;

namespace MeuPonto.StepDefinitions;

[Binding]
public class GestaoFolhasStepDefinitions
{
    private readonly ScenarioContext _scenario;

    private readonly GestaoFolhasContext _gestaoFolhas;

    private readonly GestaoFolhasDriver _gestaoFolhasDriver;

    private readonly GestaoContratosContext _gestaoContratos;

    private readonly MeuPontoDbContext _db;

    public GestaoFolhasStepDefinitions(
        ScenarioContext scenario,
        GestaoFolhasContext gestaoFolhas,
        GestaoFolhasDriver gestaoFolhasDriver,
        GestaoContratosContext gestaoContratos,
        MeuPontoDbContext db)
    {
        _scenario = scenario;

        _gestaoFolhas = gestaoFolhas;

        _gestaoFolhasDriver = gestaoFolhasDriver;

        _gestaoContratos = gestaoContratos;

        _db = db;
    }

    [Given(@"que o trabalhador qualifica a folha com o contrato '([^']*)'")]
    public void GivenQueOTrabalhadorQualificaAFolhaComOContrato(string nome)
    {
        var contrato = _db.Contratos.FirstOrDefault(x => x.Nome == nome);

        _gestaoFolhas.Folha.AssociarAo(contrato);
    }

    [Given(@"que o trabalhador deseja apurar a folha de ponto da compet�ncia '([^']*)'")]
    public void GivenQueOTrabalhadorDesejaApurarAFolhaDePontoDaCompetencia(DateTime competencia)
    {
        _gestaoFolhas.Folha.Competencia = competencia;
    }

    [Given(@"que o trabalhador anota a seguinte observa��o na folha de ponto:")]
    public void GivenQueOTrabalhadorAnotaASeguinteObservacaoNaFolhaDePonto(string observacao)
    {
        _gestaoFolhas.Folha.Observacao = observacao;
    }

    [Given(@"que o trabalhador tem uma folha de ponto aberta na compet�ncia '([^']*)'")]
    public async Task GivenQueOTrabalhadorTemUmaFolhaDePontoAbertaNaCompetencia(DateTime competencia)
    {
        _gestaoFolhas.Folha.StatusId = StatusFolhaEnum.Aberta;
        _gestaoFolhas.Folha.Competencia = competencia;

        _db.Folhas.Add(_gestaoFolhas.Folha);
        await _db.SaveChangesAsync();
    }

    [Given(@"que o trabalhador tem uma folha de ponto aberta")]
    public async Task GivenQueOTrabalhadorTemUmaFolhaDePontoAberta()
    {
        _db.Folhas.Add(_gestaoFolhas.Folha);
        await _db.SaveChangesAsync();
    }

    [Given(@"que o trabalhador tem uma folha de ponto aberta na compet�ncia")]
    public async Task GivenQueOTrabalhadorTemUmaFolhaDePontoAbertaNaCompetencia()
    {
        _db.Folhas.Add(_gestaoFolhas.Folha);
        await _db.SaveChangesAsync();
    }

    [Given(@"que o ano/m�s � '([^']*)'")]
    public void GivenQueOAnoMesE(string anoMes)
    {

    }

    [Given(@"que os pontos registrados foram:")]
    public async Task GivenQueOsPontosRegistradosForam(Table table)
    {
        var user = new ClaimsPrincipal();

        var transaction = user.CreateTransaction();

        var pontos = table.Rows.Select(row =>
        {
            var dataHora = DateTime.Parse(row["data/hora"]);

            var momento = (MomentoEnum)Enum.Parse(typeof(MomentoEnum), row["momento"]);

            var ponto = RegistroPontosFacade.CriaPonto(transaction);

            _gestaoContratos.Contrato.QualificaPonto(ponto);

            ponto.DataHora = dataHora;
            ponto.MomentoId = momento;

            return ponto;
        });

        _db.Pontos.AddRange(pontos);
        await _db.SaveChangesAsync();
    }

    #region Abrir Folha

    [When(@"o trabalhador abrir uma folha de ponto")]
    public void WhenOTrabalhadorAbrirUmaFolhaDePonto()
    {
        if (_gestaoFolhas.Folha.Contrato == null)
        {
            var contrato = _db.Contratos.FirstOrDefault();

            if (contrato == default)
            {
                contrato = _gestaoContratos.Contrato;

                _db.Contratos.Add(contrato);
                _db.SaveChanges();
            }

            _gestaoFolhas.Folha.AssociarAo(contrato);
        }


        var folhaAberta = _gestaoFolhasDriver.AbrirFolha(_gestaoFolhas.Folha);

        _gestaoFolhas.Contextualizar(folhaAberta);
    }

    [Then(@"uma folha de ponto dever� ser aberta")]
    public void ThenUmaFolhaDePontoDeveraSerAberta()
    {
        _gestaoFolhas.Folha.Should().NotBeNull();
    }

    #endregion

    #region Fechar Folha

    [When(@"o trabalhador fechar a folha de ponto")]
    public void WhenOTrabalhadorFecharAFolhaDePonto()
    {
        var folhaFechada = _gestaoFolhasDriver.FecharFolha(_gestaoFolhas.Folha);

        _gestaoFolhas.Contextualizar(folhaFechada);
    }

    [Then(@"a folha de ponto dever� ser fechada")]
    public void ThenAFolhaDePontoDeveraSerFechada()
    {
        _gestaoFolhas.Folha.StatusId.Should().Be(StatusFolhaEnum.Fechada);
    }

    #endregion

    [Then(@"o contrato da folha de ponto dever� dever� ser '([^']*)'")]
    public void ThenOContratoDaFolhaDePontoDeveraDeveraSer(string nome)
    {
        var contrato = _gestaoFolhas.Folha.Contrato;

        contrato.Nome.Should().Be(nome);
    }

    [Then(@"o status da folha de ponto dever� ser '([^']*)'")]
    public void ThenOStatusDaFolhaDePontoDeveraSer(StatusFolhaEnum status)
    {
        _gestaoFolhas.Folha.StatusId.Should().Be(status);
    }

    [Then(@"a folha de ponto dever� ter '([^']*)' dias")]
    public void ThenAFolhaDePontoDeveraTerDias(int dias)
    {
        // TODO: _gestaoFolhas.Folha.ApuracaoMensal.QuantidadeDiaria.Should().Be(dias);
    }

    [Then(@"a folha de ponto n�o dever� ter tempo total apurado")]
    public void ThenAFolhaDePontoNaoDeveraTerTempoTotalApurado()
    {
        _gestaoFolhas.Folha.ApuracaoMensal.TempoTotalApurado.Should().BeNull();
    }

    [Then(@"a folha de ponto n�o dever� ter tempo total per�odo anterior")]
    public void ThenAFolhaDePontoNaoDeveraTerTempoTotalPeriodoAnterior()
    {
        _gestaoFolhas.Folha.ApuracaoMensal.TempoTotalPeriodoAnterior.Should().BeNull();
    }

    [Then(@"a folha de ponto dever� ter uma observa��o")]
    public void ThenAFolhaDePontoDeveraTerUmaObservacao()
    {
        _gestaoFolhas.Folha.Observacao.Should().NotBeNullOrEmpty();
    }

    [Then(@"a folha de ponto n�o dever� ter uma observa��o")]
    public void ThenAFolhaDePontoNaoDeveraTerUmaObservacao()
    {
        _gestaoFolhas.Folha.Observacao.Should().BeNullOrEmpty();
    }
}
