using System;
using e_commerce.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace e_commerce.Models
{
    public class Customer
    {
        public int CustomerId {get;set;}
        public string Name{get;set;}
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
        
        public Customer()
        {
            
            CreatedAt=DateTime.Now;
            UpdatedAt=DateTime.Now;
        }

    }
}