using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using e_commerce.Models;
using System.Linq;


namespace e_commerce.Controllers
{
    public class HomeController : Controller
    {
        private CommerceContext _context;

        public HomeController ([FromServices] CommerceContext context) {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Dashboard()
        {
            ViewBag.products=_context.products.ToList();
            ViewBag.orders=_context.orders.Include(o => o.Customer).Include(o=>o.Product).ToList();
            ViewBag.customers=_context.customers.ToList();
            return View();
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Products()
        {
            List<Product> products=_context.products.ToList();
            ViewBag.products=products;
            return View();
        }
        [HttpPost]
        [Route("addProduct")]
        public IActionResult AddProduct(Product prod)
        {
            _context.products.Add(prod);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }


        [HttpGet]
        [Route("customers")]
        public IActionResult Customers()
        {
            List<Customer> allcustomers=_context.customers.ToList();
            ViewBag.customers=allcustomers;
            return View();
        }

        [HttpGet]
        [Route("removeCustomer/{id}")]
        public IActionResult RemoveCustomer(int id){
            Customer customer=_context.customers.SingleOrDefault(c=>c.CustomerId==id);
            _context.customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }

        [HttpPost]
        [Route("addcustomer")]
        public IActionResult AddCustomer(Customer cust){
            _context.customers.Add(cust);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }


        [HttpGet]
        [Route("orders")]
        public IActionResult Orders()
        {
            ViewBag.customers=_context.customers.ToList();
            ViewBag.products=_context.products.ToList();
            ViewBag.orders = _context.orders.Include(o => o.Customer).Include(o=>o.Product).ToList();
            return View();
        }

        [HttpPost]
        [Route("addOrder")]
        public IActionResult AddOrder(Order ord){
            _context.orders.Add(ord);
            Product product=_context.products.SingleOrDefault(p=>p.ProductId==ord.ProductId);
            product.quantity-=ord.quantity;
            _context.SaveChanges();
            return RedirectToAction("Orders");
        }
    }
}
