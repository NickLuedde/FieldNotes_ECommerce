using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FieldNotes.Core.Models;
using FieldNotes_ECommerce.DataAccess.InMemory;

namespace FieldNotes_ECommerce.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {

        InMemoryRepository<ProductCategory> context;

        public ProductCategoryManagerController()
        {
            context = new InMemoryRepository<ProductCategory>();
        }


        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> productsCategories = context.Collection().ToList();
            return View(productsCategories);

        }

        //Displays the page
        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        //Post the details of the Create Page
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);


            }
            else
            {
                context.Insert(productCategory);
                context.Comit();

                return RedirectToAction("Index");

            }
        }


        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategory);
            }

        }

        //Post the details of the Edit Page
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);


                }
                productCategoryToEdit.Category = productCategory.Category;
             

                context.Comit();

                return RedirectToAction("Index");

            }

        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategoryToDelete);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
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