using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FieldNotes.Core.Models;
using FieldNotes.Core.ViewModels;
using FieldNotes_ECommerce.DataAccess.InMemory;

namespace FieldNotes_ECommerce.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {

        InMemoryRepository<Product> context;
        InMemoryRepository<ProductCategory> productCategories;



        public ProductManagerController()
        {
            context = new InMemoryRepository<Product>();

            productCategories = new InMemoryRepository<ProductCategory>();
        }


        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);

        }

        //Displays the page
        public ActionResult Create()
        {

            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.ProductCategories = productCategories.Collection();

         
            return View(viewModel);
        }

        //Post the details of the Create Page
        [HttpPost]
        public ActionResult Create(Product product)
        {
           if (!ModelState.IsValid)
            {
                return View(product);
                    
                    
           } else
            {
                context.Insert(product);
                context.Comit();

                return RedirectToAction("Index");

            }
        }


        public ActionResult Edit (string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();

            } else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();
                return View(viewModel);

               
            }

        }

        //Post the details of the Edit Page
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);

            if (productToEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);


                }
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                context.Comit();

                return RedirectToAction("Index");

            }

        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productToDelete);
            }

        }

        [HttpPost]
        [ActionName ("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete== null)
            {
                return HttpNotFound();

            }
            else
            {
                context.Delete(Id);
                context.Comit();
                
                return RedirectToAction("Index");


            }
             

            

        }


    }
}