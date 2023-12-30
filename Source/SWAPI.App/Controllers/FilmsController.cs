using SWAPI.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SWAPI.App.Controllers
{
    public class FilmsController : SWAPIController
    {
        [HttpGet]
        public async Task<ActionResult> Index(int? id)
        {
            SwapiFilmsViewModel model = null;

            try
            {
                model = await ObterDados_Films(id, Enums.TypeRequest.Full);

                return View(model);
            }

            catch (Exception erro)
            {

            }

            return View();
        }
    }
}