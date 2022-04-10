using CadastroClientes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroClientes.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public JsonResult SelecionarTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            lista = Cliente.Selecionar();
            var result = new
            {
                data = lista
            };
            return Json(result); 
        }

        public JsonResult InserirAtualizarCliente(Cliente cliente)
        {
            // Cliente cliente = new Cliente("nome", "sexo", DateTime.Now, "s", "10", "20", null);
            
            if (cliente.Id != default(int))
            {
                try
                {
                    Cliente.InserirCliente(cliente);
                    var result = new
                    {
                        success = true
                    };
                    return Json(result);
                }
                catch(Exception e)
                {
                    var result = new
                    {
                        success = false
                    };
                    return Json(result);
                }
                
            }
            else{
                
                try
                {
                    Cliente.AtualizarCliente(cliente);
                    var result = new
                    {
                        success = true
                    };
                    return Json(result);
                }
                catch (Exception e)
                {
                    var result = new
                    {
                        success = false
                    };
                    return Json(result);
                }
            }

            
        }

        public JsonResult SelecionarPorID(int id)
        {
            Cliente cliente = new Cliente();
            cliente = Cliente.SelecionarId(id);
            return Json(cliente);
        }

        public JsonResult ExcluirCliente(int id)
        {
            try{
                Cliente.ExcluirCliente(id);
                var result = new
                {
                    success = true
                };
                return Json(result);
            }
            catch (Exception e){

                var result = new
                {
                    success = false
                };
                return Json(result);
            }
        }
    }
}
