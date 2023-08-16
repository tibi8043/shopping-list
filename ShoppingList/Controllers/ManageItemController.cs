using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddOnClick(Item item)
        {
            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Item");
        }

    }
}
