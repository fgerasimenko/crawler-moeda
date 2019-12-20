using Entities;
using Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaCorrente.Controllers
{
    public class DepositoController : Controller
    {
        // GET: Deposito
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Deposito(Deposito deposito)
        {
            try
            {
                ContaFactory.GetInstance().GetContaService().Deposito(deposito);

                return Json(new { message = "Deposito efetuado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }
    }
}