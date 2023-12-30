using Newtonsoft.Json;
using SWAPI.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SWAPI.App.Enums;

namespace SWAPI.App.Controllers
{
    public class HomeController : SWAPIController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return await PopularDadosExternamente();
        }

        private async Task<ActionResult> PopularDadosExternamente()
        {
            var model = new List<SwapiViewModel>();

            var entidadesAPI = new Dictionary<int, string>()
            {
                { 1, "films" },
                { 2, "people" },
                { 3, "planets" },
                { 4, "species" },
                { 5, "starships" },
                { 6, "vehicles" },
            };

            try
            {
                foreach(var item in entidadesAPI)
                {
                    switch (item.Value)
                    {
                        case "films":

                            var responseFilms = await ObterDados_Films(item.Key, TypeRequest.Partial);

                            model.Add(new SwapiViewModel()
                            {
                                Id = item.Key,
                                name = responseFilms.title,
                                type = item.Value,
                                created = responseFilms.created,
                                edited = responseFilms.edited,
                                url = responseFilms.url
                            });

                            break;

                        case "people":

                            var responsePeoples = await ObterDados_Peoples(item.Key, TypeRequest.Partial);

                            model.Add(new SwapiViewModel()
                            {
                                Id = item.Key,
                                name = responsePeoples.name,
                                type = item.Value,
                                created = responsePeoples.created,
                                edited = responsePeoples.edited,
                                url = responsePeoples.url
                            });

                            break;

                        case "planets":

                            var responsePlanets = await ObterDados_Planets(item.Key, TypeRequest.Partial);

                            model.Add(new SwapiViewModel()
                            {
                                Id = item.Key,
                                name = responsePlanets.name,
                                type = item.Value,
                                created = responsePlanets.created,
                                edited = responsePlanets.edited,
                                url = responsePlanets.url
                            });

                            break;

                        case "species":

                            var responseSpecies = await ObterDados_Especies(item.Key, TypeRequest.Partial);

                            model.Add(new SwapiViewModel()
                            {
                                Id = item.Key,
                                name = responseSpecies.name,
                                type = item.Value,
                                created = responseSpecies.created,
                                edited = responseSpecies.edited,
                                url = responseSpecies.url
                            });

                            break;

                        case "starships":

                            var responseStarsHips = await ObterDados_StarsHips(item.Key, TypeRequest.Partial);

                            model.Add(new SwapiViewModel()
                            {
                                Id = item.Key,
                                name = responseStarsHips.name,
                                type = item.Value,
                                created = responseStarsHips.created,
                                edited = responseStarsHips.edited,
                                url = responseStarsHips.url
                            });

                            break;

                        case "vehicles":

                            var responseVehicles = await ObterDados_Veiculos(item.Key, TypeRequest.Partial);

                            model.Add(new SwapiViewModel()
                            {
                                Id = item.Key,
                                name = responseVehicles.name,
                                type = item.Value,
                                created = responseVehicles.created,
                                edited = responseVehicles.edited,
                                url = responseVehicles.url
                            });

                            break;
                    }
                };

                return View(model);
            }

            catch (Exception ex)
            {

            }

            return null;
        }
    }
}