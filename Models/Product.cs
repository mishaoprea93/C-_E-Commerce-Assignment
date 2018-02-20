using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace e_commerce.Models

{
    public class Product
    {
        public int ProductId{get;set;}
        public string name{get;set;}
        public int quantity{get;set;}
        public string description{get;set;}
        public string imageurl{get;set;}
        
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
        public Product()
        {
            CreatedAt=DateTime.Now;
            UpdatedAt=DateTime.Now;
        }
    }
}