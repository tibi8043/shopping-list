using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models {
    public class Item {
        //Don't need to set the PK because the Id spelling.

        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]        
        public string Title { get; set; }
        [StringLength(110, MinimumLength = 3)]
        public string? Description { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string? FromWhere { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
