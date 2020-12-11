using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using FieldNotes.Core.Models;

namespace FieldNotes_ECommerce.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;

        List<Product> products = new List<Product>();

        public ProductRepository()
        {
           products = cache["products"] as List<Product>;

           if(products == null)
            {
                products = new List<Product>();
            }

        }

        public void Comit()
        {
            cache["products"] = products;
        }

        public void Insert (Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product productToUpate = products.Find(p => p.Id == product.Id);

            if(productToUpate != null)
            {
                productToUpate = product;
            } else
            {
                throw new Exception("Product is not found, sorry");
            }
        }

        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product is not found, sorry");
            }

        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product is not found, sorry");
}

        }



    }
}
