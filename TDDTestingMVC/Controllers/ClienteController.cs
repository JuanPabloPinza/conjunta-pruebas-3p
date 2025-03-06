using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC.Data;
using TDDTestingMVC.Models;

namespace TDDTestingMVC.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objClienteDAL = new ClienteDataAccessLayer();
        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objClienteDAL.getAllCliente().ToList();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                objClienteDAL.addCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            Cliente cliente = objClienteDAL.getClienteById(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                objClienteDAL.updateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            Cliente cliente = objClienteDAL.getClienteById(id);
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objClienteDAL.deleteCliente(id);
            return RedirectToAction("Index");
        }


    }
}
