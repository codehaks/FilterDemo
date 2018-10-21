using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Summary { get; set; }

        [Required]
        [Range(1900, 2020)]
        public int Year { get; set; }

        public int ViewCount { get; set; }
    }
}