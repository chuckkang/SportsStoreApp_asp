using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreApp.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {   //  This is going to create a fake implementation of the IproductRepsotory and will be used
            // until I return to the topic of data starage.....
            // this implements the iproduct interface by returning a fixed collectino of product objs as the balue of the products property

            new Product {Name = "Football", Price = 25 },
            new Product {Name = "Surf board", Price = 179 },
            new Product {Name = "Running Shoes", Price = 95 }
        };
    }
}
