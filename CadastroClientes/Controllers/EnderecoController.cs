using CadastroClientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CadastroClientes.Controllers
{
    public class EnderecoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult SelecionarTodos()
        {
            List<Endereco> lista = new List<Endereco>();
            lista = Endereco.Selecionar();
            return Json(lista);
        }
        
        public void InserirAtualizarEndereco(Endereco endereco)
        {
                    
            if (endereco.Id != default(int))
            {
                Endereco.InserirEndereco(endereco);
            }

            else
            {
                Endereco.AtualizarEndereco(endereco);
            }
        }

        public JsonResult SelecionarPorID(int id)
        {
            Endereco endereco = new Endereco();
            endereco = Endereco.SelecionarId(id);
            return Json(endereco);
        }

        public void ExcluirEndereco(int id)
        {
            Endereco.ExcluirEndereco(id);
        }
    }
}
