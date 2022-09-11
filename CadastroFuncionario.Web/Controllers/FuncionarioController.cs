using CadastroFuncionario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroFuncionario.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        
        public ActionResult PesquisaFuncionario() {

            FuncionarioRepository repo = new FuncionarioRepository();

            var resultado = repo.BuscaFuncionario("");
            
            return View(resultado);
        }

        [HttpPost]
        public ActionResult PesquisaFuncionarioPorNome(string txtNomeFuncionario)
        {

            FuncionarioRepository repo = new FuncionarioRepository();

            var resultado = repo.BuscaFuncionario(txtNomeFuncionario);

            return View(resultado);
        }

        public ActionResult CriarFuncionario()
        {
            ViewBag.Message = "Criar-Funcionário";

            return View();
        }

        public ActionResult AlterarFuncionario()
        {
            ViewBag.Message = "Alterar-Funcionário.";

            return View();
        }

        public ActionResult DeletarFuncionario(int CodFuncionario)
        {
            FuncionarioRepository repo = new FuncionarioRepository();

            repo.DeleteFuncionario(CodFuncionario);

            return Redirect("PesquisaFuncionario");
        }
    }
}