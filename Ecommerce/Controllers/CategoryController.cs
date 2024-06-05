using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Models.Category> objCategoryList = _db.Categories.ToList();   
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Server side validation takes place in the controller
        [HttpPost]
        public IActionResult Create(Models.Category obj)
        {
            //if(obj.Name == obj.DisplayOrder.ToString())
            //{
            //    //The key name, tells the app where to show the modal error.
            //    //In this case is right below the name input.
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            //}
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                //TempData is only available for the next render
                TempData["success"] = "Category created successfully";

                //RedirectToAction looks for the action in the same controller
                //If the action is in another controller, pass it as a parameter
                //to RedirectToAction like this:
                //return RedirectToAction("Index", "ControllerName");
                return RedirectToAction("Index");
            }
            return View();
        }   

        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }

            //Diferent ways of retreving from a DB
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=> u.Id == id).FirstOrDefault();

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");   
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Diferent ways of retreving from a DB
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=> u.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id); 
            if (obj == null) 
            { 
                return  NotFound(); 
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
