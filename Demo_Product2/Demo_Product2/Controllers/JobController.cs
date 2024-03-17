using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product2.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = jobManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            ModelState.Clear();
            JobValidator validationRules = new JobValidator();
            ValidationResult results= validationRules.Validate(job);
            if (results.IsValid)
            {
                jobManager.Insert(job);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeleteJob(int id) 
        {
            var value=jobManager.GetById(id);
            jobManager.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = jobManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            jobManager.Update(job);
            return RedirectToAction("Index");
        }
    }
}
