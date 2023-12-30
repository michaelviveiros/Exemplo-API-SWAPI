using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SWAPI.App.Models
{
    public class SwapiViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string name { get; set; }

        [Display(Name = "Tipo")]
        public string type { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime created { get; set; }

        [Display(Name = "Data de Edição")]
        public DateTime edited { get; set; }

        [Display(Name = "URL")]
        public string url { get; set; }
    }
}