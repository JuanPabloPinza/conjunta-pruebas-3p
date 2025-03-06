using System;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject.Utilities;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public class ReporteCompletoStepDefinitions
    {
        private static IWebDriver driver;

        #region Navegación a la URL principal

        [Given(@"Nos encontramos en http:\/\/localhost:(\d+)\/cliente\/Index")]
        [Given(@"Estamos en la URL principal http:\/\/localhost:(\d+)\/cliente\/Index")]
        [Given(@"Nos encontramos en la URLL  http:\/\/localhost:(\d+)\/cliente\/Index")]
        [Given(@"Nos encontramos en  http:\/\/localhost:(\d+)\/cliente\/Index")]
        public void GivenNavigateToClienteIndex(int port)
        {
            driver = WebDriverManager.GetDriver("edge");
            driver.Navigate().GoToUrl($"http://localhost:{port}/cliente/Index");
        }

        #endregion

        #region Agregar Cliente

        [Given(@"click en el boton Agregar Nuevo Cliente")]
        [Given(@"Doy click en el boton Agregar Nuevo Cliente")]
        public void GivenClickAgregarNuevoCliente()
        {
            driver.FindElement(By.XPath("//*[@id='content']/div/main/div/div/a")).Click();
        }

        [When(@"llenamos el formulario")]
        public void WhenLlenamosElFormulario(Table table)
        {
            FillForm(table);
        }

        [When(@"llenamos el formulario con los datos")]
        public void WhenLlenamosElFormularioConLosDatos(Table table)
        {
            FillForm(table);
        }

        private void FillForm(Table table)
        {
            var row = table.Rows[0];

            var cedulaInput = driver.FindElement(By.Id("Cedula"));
            cedulaInput.Clear();
            cedulaInput.SendKeys(row["Cedula"]);

            var nombresInput = driver.FindElement(By.Id("Nombres"));
            nombresInput.Clear();
            nombresInput.SendKeys(row["Nombres"]);

            var apellidosInput = driver.FindElement(By.Id("Apellidos"));
            apellidosInput.Clear();
            apellidosInput.SendKeys(row["Apellidos"]);

            var fechaNacimientoInput = driver.FindElement(By.Id("FechaNacimiento"));
            fechaNacimientoInput.Clear();
            fechaNacimientoInput.SendKeys(row["FechaNacimiento"]);

            var mailInput = driver.FindElement(By.Id("Mail"));
            mailInput.Clear();
            mailInput.SendKeys(row["Mail"]);

            var telefonoInput = driver.FindElement(By.Id("Telefono"));
            telefonoInput.Clear();
            telefonoInput.SendKeys(row["Telefono"]);
            var direccionInput = driver.FindElement(By.Id("Direccion"));
            direccionInput.Clear();
            direccionInput.SendKeys(row["Direccion"]);

            if (row.ContainsKey("Estado") && row["Estado"].Trim().ToLower() == "activo")
            {
                IWebElement estadoCheckbox = driver.FindElement(By.Id("Estado"));
                if (!estadoCheckbox.Selected)
                {
                    estadoCheckbox.Click();
                }
            }
        }

        [When(@"click en el boton Registrar Cliente")]
        [When(@"damos click en el botonn Registrar Cliente")]
        public void WhenClickRegistrarCliente()
        {
            driver.FindElement(By.Id("btnSubmit")).Click();
        }

        [Then(@"nos redirigimos a la URL iniciall	http:\/\/localhost:(\d+)\/Cliente")]
        [Then(@"el sistema nos redirige al listado de clientes http:\/\/localhost:(\d+)\/Cliente")]
        public void ThenRedireccionUrlCliente(int port)
        {
            Thread.Sleep(2000);
            string expectedUrl = $"http://localhost:{port}/Cliente";
            string actualUrl = driver.Url;
            if (!actualUrl.Equals(expectedUrl, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"La URL actual '{actualUrl}' no coincide con la esperada '{expectedUrl}'");
            }
            driver.Quit();
        }

        [Then(@"el sistema muestra un mensaje {string}")]
        public void ThenElSistemaMuestraUnMensaje(string expectedMessage)
        {
            Thread.Sleep(2000);
            IWebElement errorElement = driver.FindElement(By.CssSelector("span[data-valmsg-for='Cedula']"));
            string actualMessage = errorElement.Text.Trim();
            if (!actualMessage.Equals(expectedMessage, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"El mensaje de error esperado era '{expectedMessage}' pero se obtuvo '{actualMessage}'");
            }
            driver.Quit();
        }

        #endregion

        #region Editar Cliente

        [Given(@"damos click en el botón editar del id (\d+)")]
        public void GivenDamosClickEnElBotonEditarDelId(int id)
        {
            driver.FindElement(By.XPath($"//a[@href='/Cliente/Edit/{id}']")).Click();
        }

        [When(@"cambiamos el nombre a ""(.*)""")]
        public void WhenCambiamosElNombreA(string nuevoNombre)
        {
            IWebElement nombreInput = driver.FindElement(By.Id("Nombres"));
            nombreInput.Clear();
            nombreInput.SendKeys(nuevoNombre);
        }

        [When(@"damos click en el botón Guardar Cambios")]
        public void WhenDamosClickEnElBotonGuardarCambios()
        {
            driver.FindElement(By.Id("btnGuardar")).Click();
        }

        [When(@"cambiamos el la cedula erronea a (\d+)")]
        public void WhenCambiamosElLaCedulaErroneaA(int cedula)
        {
            IWebElement cedulaInput = driver.FindElement(By.Id("Cedula"));
            cedulaInput.Clear();
            cedulaInput.SendKeys(cedula.ToString());
        }

        [Then(@"el sistema indica un mensaje de error {string}")]
        public void ThenElSistemaIndicaUnMensajeDeError(string expectedMessage)
        {
            Thread.Sleep(2000);
            IWebElement errorElement = driver.FindElement(By.CssSelector("span[data-valmsg-for='Cedula']"));
            string actualMessage = errorElement.Text.Trim();
            if (!actualMessage.Equals(expectedMessage, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"El mensaje de error esperado era '{expectedMessage}', pero se obtuvo '{actualMessage}'");
            }
            driver.Quit();
        }

        #endregion
    }
}