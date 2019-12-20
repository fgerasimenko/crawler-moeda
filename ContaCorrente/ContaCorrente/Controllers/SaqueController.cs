using Entities;
using Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContaCorrente.Controllers
{
    public class SaqueController : Controller
    {
        // GET: Saque
        public ActionResult Index(int? id)
        {

            return View();
        }

        [HttpPost]
        public JsonResult Saque(Saque saque)
        {
            try
            {
                ContaFactory.GetInstance().GetContaService().Saque(saque);

                return Json(new { message = "Saque efetuado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }


    }
}