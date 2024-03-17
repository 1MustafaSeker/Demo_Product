using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Demo_Product2.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager=new ProductManager(new EfProductDal()); 
        public IActionResult Index()
        {
            var values=productManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ModelState.Clear();
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(product);
            if (results.IsValid)
            {
                productManager.Insert(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors) 
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
           
        }
        public IActionResult DeleteProduct(int id) 
        {
            var value = productManager.GetById(id);
            productManager.Delete(value);
            return RedirectToAction("Index");

            //productManager.Delete(product);
            //return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = productManager.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {

            productManager.Update(product);
            return RedirectToAction("index");
        }
    }
}
