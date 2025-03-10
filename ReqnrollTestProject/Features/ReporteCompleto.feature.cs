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
namespace ReqnrollTestProject.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ReporteCompletoFeature : object, Xunit.IClassFixture<ReporteCompletoFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "ReporteCompleto", "Vamos a agregar un cliente pero en este caso el teléfono va a tener solo 9 caract" +
                "eres, por ende nos va a dar un error al agregar el cliente", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ReporteCompleto.feature"
#line hidden
        
        public ReporteCompletoFeature(ReporteCompletoFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
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
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Agregar Cliente con cedula menos de 10 digitos")]
        [Xunit.TraitAttribute("FeatureTitle", "ReporteCompleto")]
        [Xunit.TraitAttribute("Description", "Agregar Cliente con cedula menos de 10 digitos")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task AgregarClienteConCedulaMenosDe10Digitos()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Agregar Cliente con cedula menos de 10 digitos", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 6
 await testRunner.GivenAsync("Nos encontramos en http://localhost:5279/cliente/Index", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 7
 await testRunner.AndAsync("click en el boton Agregar Nuevo Cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Nombres",
                            "Apellidos",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table1.AddRow(new string[] {
                            "175500892",
                            "Juan",
                            "Pinza",
                            "01/15/2004",
                            "jppinza@espe.edu.ec",
                            "1234567890",
                            "Quito",
                            "Activo"});
#line 8
 await testRunner.WhenAsync("llenamos el formulario", ((string)(null)), table1, "When ");
#line hidden
#line 11
 await testRunner.AndAsync("click en el boton Registrar Cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 12
 await testRunner.ThenAsync("el sistema muestra un mensaje \"La cédula debe tener 10 dígitos.\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Agregar Cliente con datos correctosw")]
        [Xunit.TraitAttribute("FeatureTitle", "ReporteCompleto")]
        [Xunit.TraitAttribute("Description", "Agregar Cliente con datos correctosw")]
        [Xunit.TraitAttribute("Category", "tag2")]
        public async System.Threading.Tasks.Task AgregarClienteConDatosCorrectosw()
        {
            string[] tagsOfScenario = new string[] {
                    "tag2"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Agregar Cliente con datos correctosw", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 17
 await testRunner.GivenAsync("Estamos en la URL principal http://localhost:5279/cliente/Index", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 18
 await testRunner.AndAsync("Doy click en el boton Agregar Nuevo Cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Nombres",
                            "Apellidos",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table2.AddRow(new string[] {
                            "1755008925",
                            "Juan",
                            "Pinza",
                            "01/15/2004",
                            "jppinza@espe.edu.ec",
                            "1234567890",
                            "Quito",
                            "Activo"});
#line 19
 await testRunner.WhenAsync("llenamos el formulario con los datos", ((string)(null)), table2, "When ");
#line hidden
#line 22
 await testRunner.AndAsync("damos click en el botonn Registrar Cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 23
 await testRunner.ThenAsync("nos redirigimos a la URL iniciall\thttp://localhost:5279/Cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Se va a editar un nombbre del cliente")]
        [Xunit.TraitAttribute("FeatureTitle", "ReporteCompleto")]
        [Xunit.TraitAttribute("Description", "Se va a editar un nombbre del cliente")]
        [Xunit.TraitAttribute("Category", "tag3")]
        public async System.Threading.Tasks.Task SeVaAEditarUnNombbreDelCliente()
        {
            string[] tagsOfScenario = new string[] {
                    "tag3"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Se va a editar un nombbre del cliente", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 28
 await testRunner.GivenAsync("Nos encontramos en la URLL  http://localhost:5279/cliente/Index", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 29
 await testRunner.AndAsync("damos click en el botón editar del id 7", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 30
 await testRunner.WhenAsync("cambiamos el nombre a \"Prueba\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 31
 await testRunner.AndAsync("damos click en el botón Guardar Cambios", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 32
 await testRunner.ThenAsync("el sistema nos redirige al listado de clientes http://localhost:5279/Cliente", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Se va a editar un nombre del cliente")]
        [Xunit.TraitAttribute("FeatureTitle", "ReporteCompleto")]
        [Xunit.TraitAttribute("Description", "Se va a editar un nombre del cliente")]
        [Xunit.TraitAttribute("Category", "tag4")]
        public async System.Threading.Tasks.Task SeVaAEditarUnNombreDelCliente()
        {
            string[] tagsOfScenario = new string[] {
                    "tag4"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Se va a editar un nombre del cliente", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 await testRunner.GivenAsync("Nos encontramos en  http://localhost:5279/cliente/Index", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 37
 await testRunner.AndAsync("damos click en el botón editar del id 7", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 38
 await testRunner.WhenAsync("cambiamos el la cedula erronea a 175500892", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 39
 await testRunner.AndAsync("damos click en el botón Guardar Cambios", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 40
 await testRunner.ThenAsync("el sistema indica un mensaje de error \"La cédula debe tener 10 dígitos.\"", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await ReporteCompletoFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await ReporteCompletoFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
