namespace ShoppingList.Models {
    public class Item {
        //Don't need to set the PK because the Id spelling.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FromWhere { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;


    }
}
