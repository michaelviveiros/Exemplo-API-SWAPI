using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SWAPI.App.Models;
using SWAPI.App.Enums;

namespace SWAPI.App.Controllers
{
    public class SWAPIController : Controller
    {
        /// <summary>
        /// URL da API SWAPI
        /// </summary>
        protected static string url_api_swapi
        {
            get => ConfigurationManager.AppSettings["URL_API_SWAPI"];
        }

        [HttpGet]
        public async Task<SwapiPlanetsViewModel> ObterDados_Planets(int? id, TypeRequest typeRequest)
        {
            using (var client = new HttpClient())
            {
                SwapiPlanetsViewModel model = new SwapiPlanetsViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage request = await client.GetAsync($"api/planets/{id}");

                if (request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiPlanetsViewModel>(response);

                    if (typeRequest == TypeRequest.Full)
                    {
                        if (model.residents != null && model.residents.Count() > 0)
                        {
                            model.Peoples = new List<SwapiPeopleViewModel>();

                            foreach (var item in model.residents)
                            {
                                model.Peoples.Add(await ObterDados_Peoples(item));
                            }
                        }

                        if (model.films != null && model.films.Count() > 0)
                        {
                            model.Filmes = new List<SwapiFilmsViewModel>();

                            foreach (var item in model.films)
                            {
                                model.Filmes.Add(await ObterDados_Films(item));
                            }
                        }
                    }

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        private async Task<SwapiPlanetsViewModel> ObterDados_Planets(string url)
        {
            using (var client = new HttpClient())
            {
                SwapiPlanetsViewModel model = new SwapiPlanetsViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"{url}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiPlanetsViewModel>(response);

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        public async Task<SwapiPeopleViewModel> ObterDados_Peoples(int? id, TypeRequest typeRequest)
        {
            using (var client = new HttpClient())
            {
                SwapiPeopleViewModel model = new SwapiPeopleViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage request = await client.GetAsync($"api/people/{id}");

                if (request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiPeopleViewModel>(response);

                    if(typeRequest == TypeRequest.Full)
                    {
                        if (model.films != null && model.films.Count() > 0)
                        {
                            model.Filmes = new List<SwapiFilmsViewModel>();

                            foreach (var item in model.films)
                            {
                                model.Filmes.Add(await ObterDados_Films(item));
                            }
                        }

                        if (model.starships != null && model.starships.Count() > 0)
                        {
                            model.StarsHips = new List<SwapiStarsHipsViewModel>();

                            foreach (var item in model.starships)
                            {
                                model.StarsHips.Add(await ObterDados_StarsHips(item));
                            }
                        }

                        if (model.vehicles != null && model.vehicles.Count() > 0)
                        {
                            model.Veiculos = new List<SwapiVehiclesViewModel>();

                            foreach (var item in model.vehicles)
                            {
                                model.Veiculos.Add(await ObterDados_Veiculos(item));
                            }
                        }

                        if (model.species != null && model.species.Count() > 0)
                        {
                            model.Especies = new List<SwapiSpeciesViewModel>();

                            foreach (var item in model.species)
                            {
                                model.Especies.Add(await ObterDados_Especies(item));
                            }
                        }
                    }

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        private async Task<SwapiPeopleViewModel> ObterDados_Peoples(string url)
        {
            using (var client = new HttpClient())
            {
                SwapiPeopleViewModel model = new SwapiPeopleViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"{url}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiPeopleViewModel>(response);

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        public async Task<SwapiFilmsViewModel> ObterDados_Films(int? id, TypeRequest typeRequest)
        {
            using (var client = new HttpClient())
            {
                SwapiFilmsViewModel model = new SwapiFilmsViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage request = await client.GetAsync($"api/films/{id}");

                if (request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiFilmsViewModel>(response);

                    if(typeRequest == TypeRequest.Full)
                    {
                        if (model.characters != null && model.characters.Count() > 0)
                        {
                            model.Peoples = new List<SwapiPeopleViewModel>();

                            foreach (var item in model.characters)
                            {
                                model.Peoples.Add(await ObterDados_Peoples(item));
                            }
                        }

                        if (model.planets != null && model.planets.Count() > 0)
                        {
                            model.Planetas = new List<SwapiPlanetsViewModel>();

                            foreach (var item in model.planets)
                            {
                                model.Planetas.Add(await ObterDados_Planets(item));
                            }
                        }

                        if (model.starships != null && model.starships.Count() > 0)
                        {
                            model.StarHips = new List<SwapiStarsHipsViewModel>();

                            foreach (var item in model.starships)
                            {
                                model.StarHips.Add(await ObterDados_StarsHips(item));
                            }
                        }

                        if (model.vehicles != null && model.vehicles.Count() > 0)
                        {
                            model.Veiculos = new List<SwapiVehiclesViewModel>();

                            foreach (var item in model.vehicles)
                            {
                                model.Veiculos.Add(await ObterDados_Veiculos(item));
                            }
                        }

                        if (model.species != null && model.species.Count() > 0)
                        {
                            model.Especies = new List<SwapiSpeciesViewModel>();

                            foreach (var item in model.species)
                            {
                                model.Especies.Add(await ObterDados_Especies(item));
                            }
                        }
                    }

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        private async Task<SwapiFilmsViewModel> ObterDados_Films(string url)
        {
            using (var client = new HttpClient())
            {
                SwapiFilmsViewModel model = new SwapiFilmsViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"{url}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiFilmsViewModel>(response);

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        public async Task<SwapiStarsHipsViewModel> ObterDados_StarsHips(int? id, TypeRequest typeRequest)
        {
            using (var client = new HttpClient())
            {
                SwapiStarsHipsViewModel model = new SwapiStarsHipsViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage request = await client.GetAsync($"api/starships/{id}");

                if (request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiStarsHipsViewModel>(response);

                    if(typeRequest == TypeRequest.Full)
                    {
                        if (model.pilots != null && model.pilots.Count() > 0)
                        {
                            model.Peoples = new List<SwapiPeopleViewModel>();

                            foreach (var item in model.pilots)
                            {
                                model.Peoples.Add(await ObterDados_Peoples(item));
                            }
                        }

                        if (model.films != null && model.films.Count() > 0)
                        {
                            model.Filmes = new List<SwapiFilmsViewModel>();

                            foreach (var item in model.films)
                            {
                                model.Filmes.Add(await ObterDados_Films(item));
                            }
                        }
                    }

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        private async Task<SwapiStarsHipsViewModel> ObterDados_StarsHips(string url)
        {
            using (var client = new HttpClient())
            {
                SwapiStarsHipsViewModel model = new SwapiStarsHipsViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"{url}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiStarsHipsViewModel>(response);

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        public async Task<SwapiVehiclesViewModel> ObterDados_Veiculos(int? id, TypeRequest typeRequest)
        {
            using (var client = new HttpClient())
            {
                SwapiVehiclesViewModel model = new SwapiVehiclesViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage request = await client.GetAsync($"api/vehicles/{id}");

                if (request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiVehiclesViewModel>(response);

                    if(typeRequest == TypeRequest.Full)
                    {
                        if (model.pilots != null && model.pilots.Count() > 0)
                        {
                            model.Peoples = new List<SwapiPeopleViewModel>();

                            foreach (var item in model.pilots)
                            {
                                model.Peoples.Add(await ObterDados_Peoples(item));
                            }
                        }

                        if (model.films != null && model.films.Count() > 0)
                        {
                            model.Filmes = new List<SwapiFilmsViewModel>();

                            foreach (var item in model.films)
                            {
                                model.Filmes.Add(await ObterDados_Films(item));
                            }
                        }
                    }

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        private async Task<SwapiVehiclesViewModel> ObterDados_Veiculos(string url)
        {
            using (var client = new HttpClient())
            {
                SwapiVehiclesViewModel model = new SwapiVehiclesViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"{url}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiVehiclesViewModel>(response);

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        public async Task<SwapiSpeciesViewModel> ObterDados_Especies(int? id, TypeRequest typeRequest)
        {
            using (var client = new HttpClient())
            {
                SwapiSpeciesViewModel model = new SwapiSpeciesViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage request = await client.GetAsync($"api/species/{id}");

                if (request.IsSuccessStatusCode)
                {
                    var response = request.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiSpeciesViewModel>(response);

                    if(typeRequest == TypeRequest.Full)
                    {
                        if (model.people != null && model.people.Count() > 0)
                        {
                            model.Peoples = new List<SwapiPeopleViewModel>();

                            foreach (var item in model.people)
                            {
                                model.Peoples.Add(await ObterDados_Peoples(item));
                            }
                        }

                        if (model.films != null && model.films.Count() > 0)
                        {
                            model.Filmes = new List<SwapiFilmsViewModel>();

                            foreach (var item in model.films)
                            {
                                model.Filmes.Add(await ObterDados_Films(item));
                            }
                        }
                    }

                    return model;
                }
            }

            return null;
        }

        [HttpGet]
        private async Task<SwapiSpeciesViewModel> ObterDados_Especies(string url)
        {
            using (var client = new HttpClient())
            {
                SwapiSpeciesViewModel model = new SwapiSpeciesViewModel();

                client.BaseAddress = new Uri(url_api_swapi);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"{url}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(response))
                        model = JsonConvert.DeserializeObject<SwapiSpeciesViewModel>(response);

                    return model;
                }
            }

            return null;
        }
    }
}