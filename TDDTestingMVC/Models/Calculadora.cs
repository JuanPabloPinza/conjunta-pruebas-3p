namespace TDDTestingMVC.Models
{
    public class Calculadora
    {
        public int firstNum{ get; set; }
        public int secondNum { get; set; }
        public int Sumar(int a, int b)
        {
            return a + b;
        }
    }
}
