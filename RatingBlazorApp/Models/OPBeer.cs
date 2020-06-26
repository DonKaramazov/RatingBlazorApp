using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatingBlazorApp.Models
{
    public class OPBeer
    {
        [Required(ErrorMessage ="Le nom est obligatoire.")]
        [StringLength(32, ErrorMessage = "Le nom est limité à 32 caractères.")]
        public string Name { get; set; }
        public string Description { get; set; }
        
        [Required(ErrorMessage = "La couleur est obligatoire.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Le style est obligatoire.")]
        public string Style { get; set; }


        /// <summary>
        /// Alcool By Volume
        /// </summary>
        [Required(ErrorMessage = "Le taux d'alcool par volume est obligatoire.")]
        [Range(0,99,ErrorMessage = "Le taux d'alcool par volume est entre 0 et 99%")]
        public string Abv { get; set; }
    }
}
