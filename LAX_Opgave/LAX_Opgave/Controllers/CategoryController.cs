using LAX_Opgave.Data;
using LAX_Opgave.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAX_Opgave.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;

            return View(objCategoryList);
        }
    }
}
