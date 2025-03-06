using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace TDDTestingMVC.Data
{
    public class Pedido
    {
        public int PedidoID { get; set; }

        [Required(ErrorMessage = "El Cliente es obligatorio.")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El estado no puede tener más de 50 caracteres.")]
        public string Estado { get; set; }
    }
}
