using Entities;
using Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaCorrente.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Registro(Conta conta)
        {
            try
            {
                ContaFactory.GetInstance().GetContaService().Save(conta);

                return Json(new { message = "Conta Criada com sucesso!" });
            }
            catch(Exception ex)
            {
                return Json(new { message = ex.Message });
            }

        }

        [HttpPost]
        public JsonResult Atualizar(Conta conta)
        {
            try
            {
                ContaFactory.GetInstance().GetContaService().Save(conta);

                return Json(new { message = "Conta Criada com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }
    }
}