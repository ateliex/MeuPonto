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
    public partial class MarcacaoPontosFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("pt-br"), "Features", "Marcacao Pontos", "O sistema deverá fornecer para o trabalhador a capacidade de marcar um ponto", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "MarcacaoPontos.feature"
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Marcar Ponto] Trabalhador marca os pontos de entrada e saída do expediente")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Marcacao Pontos")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("main")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("27/11/2022 09:14", "Marcelo - Ateliex", "Entrada", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("27/11/2022 18:05", "Marcelo - Ateliex", "Saida", null)]
        public async System.Threading.Tasks.Task MarcarPontoTrabalhadorMarcaOsPontosDeEntradaESaidaDoExpediente(string dataHora, string contrato, string momentoId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "main"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("data/hora", dataHora);
            argumentsOfScenario.Add("contrato", contrato);
            argumentsOfScenario.Add("momento id", momentoId);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Marcar Ponto] Trabalhador marca os pontos de entrada e saída do expediente", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 await testRunner.GivenAsync(string.Format("que a data/hora do relógio é \'{0}\'", dataHora), ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 12
 await testRunner.AndAsync(string.Format("que existe um contrato aberto \'{0}\'", contrato), ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 13
 await testRunner.WhenAsync("o trabalhador solicitar uma marcação de ponto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 14
 await testRunner.ThenAsync("o sistema deverá apresentar um ponto novo", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
                global::Reqnroll.Table table21 = new global::Reqnroll.Table(new string[] {
                            "contrato",
                            "momento id"});
                table21.AddRow(new string[] {
                            string.Format("{0}", contrato),
                            string.Format("{0}", momentoId)});
#line 15
 await testRunner.WhenAsync("o trabalhador marcar o ponto como:", ((string)(null)), table21, "Quando ");
#line hidden
#line 18
 await testRunner.ThenAsync(string.Format("a data do ponto deverá ser \'{0}\'", dataHora), ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 19
 await testRunner.AndAsync(string.Format("o ponto deverá ser qualificado pelo contrato \'{0}\'", contrato), ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 20
 await testRunner.AndAsync(string.Format("o momento do ponto deverá ser de \'{0}\'", momentoId), ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 21
 await testRunner.ButAsync("o ponto não deverá indicar que foi uma pausa", ((string)(null)), ((global::Reqnroll.Table)(null)), "Mas ");
#line hidden
#line 22
 await testRunner.AndAsync("o ponto não deverá indicar que foi estimado", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 23
 await testRunner.AndAsync("o ponto não deverá ter uma observação", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Marcar Ponto] Trabalhador marca os pontos de pausa do expediente")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Marcacao Pontos")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("alter")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Marcelo - Ateliex", "Saida", "Almoco", null)]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute("Marcelo - Ateliex", "Entrada", "Almoco", null)]
        public async System.Threading.Tasks.Task MarcarPontoTrabalhadorMarcaOsPontosDePausaDoExpediente(string contrato, string momentoId, string pausaId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "alter"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("contrato", contrato);
            argumentsOfScenario.Add("momento id", momentoId);
            argumentsOfScenario.Add("pausa id", pausaId);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Marcar Ponto] Trabalhador marca os pontos de pausa do expediente", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 34
 await testRunner.GivenAsync(string.Format("que existe um contrato aberto \'{0}\'", contrato), ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 35
 await testRunner.WhenAsync("o trabalhador solicitar uma marcação de ponto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
                global::Reqnroll.Table table22 = new global::Reqnroll.Table(new string[] {
                            "contrato",
                            "momento id",
                            "pausa id"});
                table22.AddRow(new string[] {
                            string.Format("{0}", contrato),
                            string.Format("{0}", momentoId),
                            string.Format("{0}", pausaId)});
#line 36
 await testRunner.AndAsync("o trabalhador marcar o ponto como:", ((string)(null)), table22, "E ");
#line hidden
#line 40
 await testRunner.ThenAsync(string.Format("o momento do ponto deverá ser de \'{0}\'", momentoId), ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 41
 await testRunner.AndAsync(string.Format("a pausa do ponto deverá ser \'{0}\'", pausaId), ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("[Marcar Ponto] Trabalhador marca o ponto justificando porque chegou atrasado")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Marcacao Pontos")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("alter")]
        public async System.Threading.Tasks.Task MarcarPontoTrabalhadorMarcaOPontoJustificandoPorqueChegouAtrasado()
        {
            string[] tagsOfScenario = new string[] {
                    "alter"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("[Marcar Ponto] Trabalhador marca o ponto justificando porque chegou atrasado", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 52
 await testRunner.GivenAsync("que existe um contrato aberto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 53
 await testRunner.AndAsync("que existe uma marcação de ponto em andamento", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 54
 await testRunner.WhenAsync("o trabalhador marcar o ponto com a seguinte observação:", "Hoje o trânsito estava lento.", ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 58
 await testRunner.ThenAsync("a observação do ponto deverá ser:", "Hoje o trânsito estava lento.", ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
