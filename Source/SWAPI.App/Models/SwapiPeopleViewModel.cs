using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWAPI.App.Models
{
    public class SwapiPeopleViewModel
    {
        public string name { get; set; }

        public string height { get; set; }

        public string mass { get; set; }

        public string hair_color { get; set; }

        public string skin_color { get; set; }

        public string eye_color { get; set; }

        public string birth_year { get; set; }

        public string gender { get; set; }

        public string homeworld { get; set; }

        public List<string> films { get; set; }

        public List<string> species { get; set; }

        public List<string> vehicles { get; set; }

        public List<string> starships { get; set; }

        public DateTime created { get; set; }

        public DateTime edited { get; set; }

        public string url { get; set; }


        public List<SwapiFilmsViewModel> Filmes { get; set; }

        public List<SwapiSpeciesViewModel> Especies { get; set; }

        public List<SwapiVehiclesViewModel> Veiculos { get; set; }

        public List<SwapiStarsHipsViewModel> StarsHips { get; set; }
    }
}