﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MeuPonto.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class GestaoFolhasFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("pt-br"), "Features", "Gestão Folhas", "O sistema deverá fornecer para o trabalhador a capacidade de gerenciar suas folha" +
                "s.", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "GestaoFolhas.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute(Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupBehavior.EndOfClass)]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Abrir Folha] Trabalhador abre uma folha de ponto usando seu único contrato")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Gestão Folhas")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("wip")]
        public async System.Threading.Tasks.Task AbrirFolhaTrabalhadorAbreUmaFolhaDePontoUsandoSeuUnicoContrato()
        {
            string[] tagsOfScenario = new string[] {
                    "wip"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Abrir Folha] Trabalhador abre uma folha de ponto usando seu único contrato", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 11
 await testRunner.GivenAsync("que existe um contrato aberto \'Marcelo - Ateliex\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 12
 await testRunner.AndAsync("que o trabalhador qualifica a folha com o contrato \'Marcelo - Ateliex\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 13
 await testRunner.WhenAsync("o trabalhador abrir uma folha de ponto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 14
 await testRunner.ThenAsync("uma folha de ponto deverá ser aberta", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 15
 await testRunner.AndAsync("o contrato da folha de ponto deverá deverá ser \'Marcelo - Ateliex\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Abrir Folha] Trabalhador abre uma folha ponto para o mês de novembro de 2022")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Gestão Folhas")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("wip")]
        public async System.Threading.Tasks.Task AbrirFolhaTrabalhadorAbreUmaFolhaPontoParaOMesDeNovembroDe2022()
        {
            string[] tagsOfScenario = new string[] {
                    "wip"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Abrir Folha] Trabalhador abre uma folha ponto para o mês de novembro de 2022", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 21
 await testRunner.GivenAsync("que existe um contrato aberto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 22
 await testRunner.AndAsync("que o trabalhador deseja apurar a folha de ponto da competência \'2022/11\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 23
 await testRunner.WhenAsync("o trabalhador abrir uma folha de ponto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 24
 await testRunner.ThenAsync("uma folha de ponto deverá ser aberta", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 25
 await testRunner.AndAsync("o status da folha de ponto deverá ser \'Aberta\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 26
 await testRunner.AndAsync("a folha de ponto deverá ter \'30\' dias", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 28
 await testRunner.ButAsync("a folha de ponto não deverá ter tempo total apurado", ((string)(null)), ((global::Reqnroll.Table)(null)), "Mas ");
#line hidden
#line 29
 await testRunner.AndAsync("a folha de ponto não deverá ter tempo total período anterior", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 30
 await testRunner.AndAsync("a folha de ponto não deverá ter uma observação", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Abrir Folha] Trabalhador abre uma folha de ponto anotando que deve confirmar os " +
            "feriados do mês")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Gestão Folhas")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("wip")]
        public async System.Threading.Tasks.Task AbrirFolhaTrabalhadorAbreUmaFolhaDePontoAnotandoQueDeveConfirmarOsFeriadosDoMes()
        {
            string[] tagsOfScenario = new string[] {
                    "wip"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Abrir Folha] Trabalhador abre uma folha de ponto anotando que deve confirmar os " +
                    "feriados do mês", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 36
 await testRunner.GivenAsync("que existe um contrato aberto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 37
 await testRunner.AndAsync("que o trabalhador anota a seguinte observação na folha de ponto:", "Verificar se a última sexta-feira do mês vai ser feriado.", ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 41
 await testRunner.WhenAsync("o trabalhador abrir uma folha de ponto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 42
 await testRunner.ThenAsync("uma folha de ponto deverá ser aberta", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 43
 await testRunner.AndAsync("a folha de ponto deverá ter uma observação", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Fechar Folha] Trabalhador confirma que uma folha de ponto aberta foi fechada")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Gestão Folhas")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("wip")]
        public async System.Threading.Tasks.Task FecharFolhaTrabalhadorConfirmaQueUmaFolhaDePontoAbertaFoiFechada()
        {
            string[] tagsOfScenario = new string[] {
                    "wip"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Fechar Folha] Trabalhador confirma que uma folha de ponto aberta foi fechada", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 48
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 49
 await testRunner.GivenAsync("que o trabalhador tem uma folha de ponto aberta na competência \'2022/11\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 50
 await testRunner.AndAsync("que o ano/mês é \'2022/11\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 51
 await testRunner.WhenAsync("o trabalhador fechar a folha de ponto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 52
 await testRunner.ThenAsync("a folha de ponto deverá ser fechada", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 53
 await testRunner.AndAsync("o status da folha de ponto deverá ser \'Fechada\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Fechar Folha] Trabalhador guarda a apuração mensal dos pontos registrados")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Gestão Folhas")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("wip")]
        public async System.Threading.Tasks.Task FecharFolhaTrabalhadorGuardaAApuracaoMensalDosPontosRegistrados()
        {
            string[] tagsOfScenario = new string[] {
                    "wip"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Fechar Folha] Trabalhador guarda a apuração mensal dos pontos registrados", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 58
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 59
 await testRunner.GivenAsync("que o trabalhador tem uma folha de ponto aberta na competência \'2022/11\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 60
 await testRunner.AndAsync("que o ano/mês é \'2022/11\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
                global::Reqnroll.Table table20 = new global::Reqnroll.Table(new string[] {
                            "data/hora",
                            "momento"});
                table20.AddRow(new string[] {
                            "27/11/2022 09:14",
                            "Entrada"});
                table20.AddRow(new string[] {
                            "27/11/2022 11:30",
                            "Saida"});
                table20.AddRow(new string[] {
                            "27/11/2022 12:27",
                            "Entrada"});
                table20.AddRow(new string[] {
                            "27/11/2022 18:03",
                            "Saida"});
#line 61
 await testRunner.AndAsync("que os pontos registrados foram:", ((string)(null)), table20, "E ");
#line hidden
#line 67
 await testRunner.WhenAsync("o trabalhador fechar a folha de ponto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 68
 await testRunner.ThenAsync("a folha de ponto deverá ser fechada", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 69
 await testRunner.AndAsync("o tempo total apurado deverá ser \'07:52\'", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 70
 await testRunner.ButAsync("o tempo total período anterior deverá ser nulo", ((string)(null)), ((global::Reqnroll.Table)(null)), "Mas ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
