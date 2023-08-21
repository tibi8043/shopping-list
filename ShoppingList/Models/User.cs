using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShoppingList.Models {
    public class User : IdentityUser{ 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
