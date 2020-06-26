using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class BeerModel
    {
        public int IdBee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Style { get; set; }

        /// <summary>
        /// Alcool By Volume
        /// </summary>
        public decimal Abv { get; set; }
    }
}
