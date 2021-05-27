using HamApp.Models;
using HamApp.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HamApp.V1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            var model = service.GetCategories();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Category created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Category could not be created");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);

            return View(model);
        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;



        }
       
        public ActionResult Edit (int id)
        {
            var service = CreateCategoryService();
            var detail = service.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    Id = detail.Id,
                    Name = detail.Name
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCategoryService();
            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "category updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Category could not be updated");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCategoryService();
            service.DeleteCategory(id);
            TempData["SaveResult"] = "Category deleted";

            return RedirectToAction("Index");
        }
    }
}