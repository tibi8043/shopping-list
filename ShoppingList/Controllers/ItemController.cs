using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Controllers {
    public class ItemController : Controller {
        private readonly MyDbContext _dbContext;

        public ItemController(MyDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IActionResult Index() {
            List<Item> items = _dbContext.Items.ToList();
            return View(items);
        }
        

    }
}