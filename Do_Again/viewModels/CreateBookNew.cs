using Do_Again.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Do_Again.viewModels
{
    public class CreateBookNew
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter the price")]
        public int Price { get; set; }
       

        public IFormFile Photopath { get; set; }
        public int TypeOfBookid { get; set; }
        public List <Do_Again.Models.TypeOfBook> categorys { get; set; }
    }
}
