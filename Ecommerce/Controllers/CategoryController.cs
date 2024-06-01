using Ecommerce.Data;
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
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();

                //RedirectToAction looks for the action in the same controller
                //If the action is in another controller, pass it as a parameter
                //to RedirectToAction like this:
                //return RedirectToAction("Index", "ControllerName");
                return RedirectToAction("Index");
            }
            return View();
        }   
    }
}
