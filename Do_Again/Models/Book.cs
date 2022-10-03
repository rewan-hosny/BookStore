using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Do_Again.Models
{

    [Table("book")]
    public class Book
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string   Name { get; set; }
        
        [Required (ErrorMessage = "You must enter the price")]
        public int Price { get; set; }
     [Required(ErrorMessage ="You must enter the photo of the book")]
      
        public string Photopath { get; set; }
        [Required(ErrorMessage = "You must enter the Type Of Book")]


        [ForeignKey("TypeOfBook")]
        public int TypeofbookId { get; set; }


        public IList<Order> orders { get; } = new List<Order>();
        public IList<ShoppingCartItem> ShoppingCartItems { get; } = new List<ShoppingCartItem>();


    }
}
