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

        public IActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
            
        }

        //EDIT

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
                return NotFound();

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id ==id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);

        }


        //DELETE

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id ==id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
           
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
