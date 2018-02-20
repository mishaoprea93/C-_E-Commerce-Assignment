using System;
namespace e_commerce.Models
{
    public class Order
    {
        public int OrderId{get;set;}
        public int CustomerId{get;set;}
        public Customer Customer{get;set;}
        public int ProductId{get;set;}
        public Product Product{get;set;}
        public int quantity{get;set;}
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
        public Order(){
            CreatedAt=DateTime.Now;
            UpdatedAt=DateTime.Now;
        }
    }
}