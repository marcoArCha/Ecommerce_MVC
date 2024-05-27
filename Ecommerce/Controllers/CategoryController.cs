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
    }
}
