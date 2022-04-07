using CadastroClientes.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CadastroClientes.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public ActionResult SelecionarTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            lista = Cliente.Selecionar();
            var result = new
            {
                data = lista
            };
            return new JsonResult(result); 
        }

        public void InserirAtualizarCliente(Cliente cliente)
        {
           // Cliente cliente = new Cliente("nome", "sexo", DateTime.Now, "s", "10", "20", null);          
            if(cliente.Id != default(int))
            {
                Cliente.InserirCliente(cliente);
            }

            else
            {
                Cliente.AtualizarCliente(cliente);
            }
        }

        public ActionResult SelecionarPorID(int id)
        {
            Cliente cliente = new Cliente();
            cliente = Cliente.SelecionarId(id);
            return Json(cliente);
        }

        public void ExcluirCliente(int id)
        {
            Cliente.ExcluirCliente(id);
        }
    }
}
