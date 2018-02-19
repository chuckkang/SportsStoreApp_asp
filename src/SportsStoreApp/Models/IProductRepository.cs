using System;
using System.Collections.Generic;
using System.Linq;


namespace SportsStoreApp.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products{ get; }

    }
}
