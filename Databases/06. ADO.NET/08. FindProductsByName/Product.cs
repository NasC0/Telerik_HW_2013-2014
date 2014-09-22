using System.Text;

namespace _08.FindProductsByName
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int CategoryID { get; set; }

        public int SupplierID { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public int OnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            StringBuilder productToString = new StringBuilder();
            productToString.AppendLine("ID: " + this.ID);
            productToString.AppendLine("Name: " + this.Name);
            productToString.AppendLine("SupplierID: " + this.SupplierID);
            productToString.AppendLine("CategoryID: " + this.CategoryID);
            productToString.AppendLine("Quantity: " + this.Quantity);
            productToString.AppendLine("Price: " + this.Price);
            productToString.AppendLine("Units in stock: " + this.InStock);
            productToString.AppendLine("Units on order: " + this.OnOrder);
            productToString.AppendLine("Reorder Level: " + this.ReorderLevel);
            productToString.AppendLine("Discontinued: " + this.IsDiscontinued);

            return productToString.ToString();
        }
    }
}
