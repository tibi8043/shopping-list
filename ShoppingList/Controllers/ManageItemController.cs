using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Controllers {
    public class ManageItemController : Controller {
        private readonly MyDbContext _dbContext;
        private readonly IToastNotification _toastNotification;

        public ManageItemController(MyDbContext dbContext, IToastNotification toastNotification) {
            _dbContext = dbContext;
            _toastNotification = toastNotification;
        }

        public IActionResult Index() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOnClick(Item item) {
            if (ModelState.IsValid) {
                _dbContext.Items.Add(item);
                _dbContext.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Added succesfully");
                return RedirectToAction("Index", "Item");
            }
            return View(item);

        }
        public IActionResult DeleteOnClick(int? id) {

            if (id == null) {
                _toastNotification.AddErrorToastMessage("Not Found");
                return NotFound();
            }

            Item i = _dbContext.Items.FirstOrDefault(i => i.Id == id);

            if (i != null) {
                _dbContext.Remove(i);
                _dbContext.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Deleted Successfully");
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
            return RedirectToAction("Index", "Item");
        }
        //EDIT
        //get
        public IActionResult Edit(int? id) {

            if (id == null) {
                return NotFound();
            }
            var itemFromDb = _dbContext.Items.FirstOrDefault(itemFromDb => itemFromDb.Id == id);
            if (itemFromDb == null) {
                _toastNotification.AddErrorToastMessage("Not Found");
                return NotFound();
            }
            return View(itemFromDb);

        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item i) {
            if (ModelState.IsValid) {
                _dbContext.Items.Update(i);
                _dbContext.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Edited Successfully");
                return RedirectToAction("Index", "Item");

            }
            return View(i);
        }

    }
}
