using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStoreApp.Models;
using Microsoft.AspNetCore.Mvc;



namespace SportsStoreApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4; // This pagesize will be used for Pagination

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        // the int page = 1 in the paramater list is an optional parameter.
        // if I don't supply a parameter then it will use 1.
        public ViewResult List(int page = 1) => View(
            repository.Products.OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize));
        
    }
}
