using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Controllers {
    public class ManageItemController : Controller {
        private readonly MyDbContext _dbContext;

        public ManageItemController(MyDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IActionResult Index() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOnClick(Item item) {
            if(ModelState.IsValid) {
                _dbContext.Items.Add(item);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Item");
            }
            return View(item);

        }
        public IActionResult DeleteOnClick(int? id) {

            if (id == null) {
                return NotFound();
            }

            Item i = _dbContext.Items.FirstOrDefault(i => i.Id == id);

            if (i != null) {
                _dbContext.Remove(i);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Item");
        }
        
        public IActionResult DoneOnClick(int? id) {
            Item i = _dbContext.Items.FirstOrDefault(i => i.Id == id);
            if (i != null) {
                if (i.IsDone) {
                    i.IsDone = false;
                }
                else {
                    i.IsDone = true;
                }                
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index","Item");
        }
        //EDIT
        //get
        public IActionResult Edit(int? id) {

            if(id == null) {
                return NotFound();
            }
            var itemFromDb = _dbContext.Items.FirstOrDefault(itemFromDb => itemFromDb.Id == id);
            if(itemFromDb == null) {
                return NotFound();
            }
            return View(itemFromDb);
            
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item i) {
            if(ModelState.IsValid) {
                _dbContext.Items.Update(i);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Item");
            }
            return View(i);
        }

    }
}
