using BulkBook.Data;
using BulkBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkBook.Controllers
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

            // Good: Don't have to write a SQL query statement
            //var objCategoryList = _db.Categories.ToList();
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }


        // GET
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            //Custom validations

            if(obj.Name == obj.DisplayOrder.ToString())
            {
               // ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name"); // This outputs the error message underneath the name (matches the name property in the category class)
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                // This will redirect to line 16.. method called IActionResult Index()
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            // Three ways to retrieve category
            var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            //Custom validations

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name");
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name"); // This outputs the error message underneath the name (matches the name property in the category class)
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                // This will redirect to line 16.. method called IActionResult Index()
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Three ways to retrieve category
            var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
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
            TempData["success"] = "Category deleted successfully";
            // This will redirect to line 16.. method called IActionResult Index()
            return RedirectToAction("Index");

            
        }
    }
}
