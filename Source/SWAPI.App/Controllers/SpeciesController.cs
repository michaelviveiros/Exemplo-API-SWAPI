using SWAPI.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SWAPI.App.Controllers
{
    public class SpeciesController : SWAPIController
    {
        [HttpGet]
        public async Task<ActionResult> Index(int? id)
        {
            if (ModelState.IsValid)
            {
                SwapiSpeciesViewModel model = null;

                try
                {
                    model = await ObterDados_Especies(id, Enums.TypeRequest.Full);

                    return View(model);
                }

                catch (Exception ex)
                {

                }
            }

            return View();
        }
    }
}