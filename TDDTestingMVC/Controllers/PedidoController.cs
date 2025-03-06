using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TDDTestingMVC.Data;
using TDDTestingMVC.Models;

namespace TDDTestingMVC.Controllers
{
    public class PedidoController : Controller
    {
        PedidoDataAccessLayer objPedidoDAL = new PedidoDataAccessLayer();
        // Instancia del DataAccessLayer de Cliente para obtener la lista de clientes válidos.
        ClienteDataAccessLayer objClienteDAL = new ClienteDataAccessLayer();

        public IActionResult Index()
        {
            var pedidos = objPedidoDAL.getAllPedido();
            return View(pedidos);
        }

        public IActionResult Create()
        {
            // Cargamos el dropdown de clientes.
            ViewBag.Clientes = new SelectList(objClienteDAL.getAllCliente(), "Codigo", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                objPedidoDAL.addPedido(pedido);
                return RedirectToAction("Index");
            }
            ViewBag.Clientes = new SelectList(objClienteDAL.getAllCliente(), "Codigo", "Nombre", pedido.ClienteID);
            return View(pedido);
        }

        public IActionResult Edit(int id)
        {
            Pedido pedido = objPedidoDAL.getPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            // Cargar el dropdown de clientes con el cliente seleccionado
            ViewBag.Clientes = new SelectList(objClienteDAL.getAllCliente(), "Codigo", "Nombre", pedido.ClienteID);
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                objPedidoDAL.updatePedido(pedido);
                return RedirectToAction("Index");
            }
            // Si hay errores de validación, se recarga el listado de clientes
            ViewBag.Clientes = new SelectList(objClienteDAL.getAllCliente(), "Codigo", "Nombre", pedido.ClienteID);
            return View(pedido);
        }

        public IActionResult Delete(int id)
        {
            Pedido pedido = objPedidoDAL.getPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objPedidoDAL.deletePedido(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Pedido pedido = objPedidoDAL.getPedidoById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }
    }
}
