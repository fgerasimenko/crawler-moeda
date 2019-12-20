using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Services;
using Services.Factories;

namespace ContaCorrente.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        // GET: Conta
        public ActionResult Conta()
        {
            try
            {
                
                var id = Convert.ToInt32(Request.QueryString["id"]);
                if (id == 0)
                    RedirectToAction("Index", "Conta");

                ViewBag.Conta = GetDetails(id);

                return View();
            }
            catch(Exception ex)
            {
                throw new Exception("Conta não encontrada");
            }
            
        }

        // GET: Conversão
        public decimal Converter(string quantia)
        {
            try
            {

                var conversao = ConversaoFactory.GetInstance().GetConversaoService().GetCotacao(Convert.ToDecimal(quantia));
                return conversao;
            }
            catch (Exception ex)
            {
                throw new Exception("Algo deu errado");
            }

        }

        public Conta GetDetails(int id)
        {
            var conta = ContaFactory.GetInstance().GetContaService().GetConta(id);

            return conta;
        }
    }
}