﻿using System.ComponentModel.DataAnnotations;

namespace Do_Again.Models
{
    public class ShoppingCartItem
    {
         
        [Key]
        public int Id { get; set; }

        public Book book { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}

