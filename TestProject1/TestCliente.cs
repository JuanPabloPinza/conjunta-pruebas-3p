using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;


namespace TestProject1
{
    public class TestCliente : IDisposable
    {
        private readonly IWebDriver driver;
        public TestCliente()
        {
            driver = new EdgeDriver();
        }

        //[Fact]
        public void Create_ReturnCreateView()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/cliente/Create");
            driver.FindElement(By.Id("Cedula")).SendKeys("1755008925");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Nombres")).SendKeys("Juan");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Apellidos")).SendKeys("Pinza");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("FechaNacimiento")).SendKeys("01/01/2025");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Mail")).SendKeys("pinza153@hotmail.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Telefono")).SendKeys("0493959432");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);
            //En ese caso se redirige al index:
            Assert.Equal("http://localhost:5279/cliente", driver.Url);
            Thread.Sleep(2000);
                        Dispose();

        }
        //Ahora, caso de prueba para el READ:
        [Fact]
        public void TC_CargarClientes()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/");
            Thread.Sleep(2000);

            var btnVerClientes = driver.FindElement(By.Id("btnVerClientes"));
            btnVerClientes.Click();
            Thread.Sleep(2000);

            Assert.Equal("http://localhost:5279/cliente", driver.Url);

            var filas = driver.FindElements(By.XPath("//tbody/tr"));
            Assert.True(filas.Count > 0, "No se cargaron filas de clientes.");

            Dispose();
        }



        //Ahora un caso de prueba en el que inserte todos los datos correctos.
        [Fact]
        public void TC_RegistroValido()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/cliente/Create");
            driver.FindElement(By.Id("Cedula")).SendKeys("1755008925");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Nombres")).SendKeys("Juan");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Apellidos")).SendKeys("Pinza");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("FechaNacimiento")).SendKeys("15/03/2004");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Mail")).SendKeys("pinza153@hotmail.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Telefono")).SendKeys("0995849355");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Direccion")).SendKeys("0995849355");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            //En ese caso se redirige al index:
            Assert.Equal("http://localhost:5279/Cliente", driver.Url);
            Dispose();
        }

        //Validación del envío de datos vacíos en un formulario.
        [Fact]
        public void TC_FormVacio()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/cliente/Create");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("Cedula")).SendKeys("");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Nombres")).SendKeys("");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Apellidos")).SendKeys("");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("FechaNacimiento")).SendKeys("");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Mail")).SendKeys("");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Telefono")).SendKeys("");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            //En este caso voy a usar mi lógica de validación, como el form no se envió, no me debería reenviar a ninguna página
            //Ya que no se puede capturar los required.
            Assert.Equal("http://localhost:5279/cliente/Create", driver.Url);
            Dispose();
        }

        //Ahora un caso de uso donde se envía un formulario con datos incorrectos (Cédula de 9 dígitos):
        [Fact]
        public void TC_FormCedulaIncorrecta()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/cliente/Create");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("Cedula")).SendKeys("175500892");
            Thread.Sleep(1000);

            driver.FindElement(By.Id("Nombres")).SendKeys("Juan");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Apellidos")).SendKeys("Pinza");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("FechaNacimiento")).SendKeys("01/01/2025");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Mail")).SendKeys("pinza153@hotmail.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Telefono")).SendKeys("0493959432");
            Thread.Sleep(1000);

            driver.FindElement(By.Id("btnSubmit")).Click();
            Thread.Sleep(1000);

            try
            {
                var cedulaError = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/main/div[1]/form/div[1]/div/span"));
                Assert.NotNull(cedulaError);
                Console.WriteLine("Error de cédula validado correctamente.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("No se encontró el mensaje de error de cédula.");
            }

            Dispose();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        //AHORA LOS CASOS DE PRUEBAS PARA EDITAR:
        //Mi lógica es: En la tabla tenemos un código, presionamos editar, luego editamos el campo, y al guardar debo comprobar que el mismo
        // Código tenga el nuevo valor.
        [Fact]
        public void TC_EditarCliente()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/Cliente");
            Thread.Sleep(2000);

            var editLink = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/main/div/table/tbody/tr[4]/td[9]/a[1]"));
            editLink.Click();
            Thread.Sleep(2000);

            var cedulaField = driver.FindElement(By.Id("Cedula"));
            cedulaField.Clear();
            string nuevoValorCedula = "1755008925";
            cedulaField.SendKeys(nuevoValorCedula);
            Thread.Sleep(1000);

            driver.FindElement(By.Id("btnGuardar")).Click();
            Thread.Sleep(2000);

            Assert.Equal("http://localhost:5279/Cliente", driver.Url);

            var updatedCedula = driver.FindElement(By.XPath("//tr[td[text()='7']]/td[6]")).Text;
            Assert.Equal(nuevoValorCedula, updatedCedula);

            Dispose();
        }
        [Fact]
        public void TC_EditarCliente_CedulaIncorrecta()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/Cliente");
            Thread.Sleep(2000);

            var editLink = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/main/div/table/tbody/tr[1]/td[9]/a[1]"));
            editLink.Click();
            Thread.Sleep(2000);

            var cedulaField = driver.FindElement(By.Id("Cedula"));
            cedulaField.Clear();
            cedulaField.SendKeys("17550095");
            Thread.Sleep(1000);


            driver.FindElement(By.CssSelector("button.btn.btn-success")).Click();
            Thread.Sleep(2000);

            //Corroboro que sigo en la misma página:
            Assert.Equal("http://localhost:5279/Cliente/Edit/1", driver.Url);
            try
            {
                var cedulaError = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/main/div[1]/form/div[1]/span"));
                Assert.NotNull(cedulaError);
                Console.WriteLine("Error de cédula validado correctamente.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("No se encontró el mensaje de error de cédula.");
            }
            Dispose();
        }

        //AHORA CASOS DE PRUEBAS PARA ELIMINAR:
        [Fact]
        public void TC_EliminarCliente()
        {
            driver.Navigate().GoToUrl("http://localhost:5279/Cliente");
            Thread.Sleep(2000);

            var deleteLink = driver.FindElement(By.XPath("//tr[td[text()='4']]/td/a[contains(text(),'Eliminar')]"));
            deleteLink.Click();
            Thread.Sleep(2000);

            var deleteButton = driver.FindElement(By.XPath("//button[text()='Eliminar']"));
            deleteButton.Click();
            Thread.Sleep(2000);

            Assert.Equal("http://localhost:5279/Cliente", driver.Url);

            var elementosConId3 = driver.FindElements(By.XPath("//tr[td[text()='3']]"));
            Assert.Empty(elementosConId3);

            Dispose();
        }


    }
}
