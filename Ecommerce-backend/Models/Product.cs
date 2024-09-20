namespace Ecommerce_backend.Models{
 
public class Product
{
    public int Id { get; set; }
    public string Img { get; set; }
    public string Title { get; set; }
    public string Reviews { get; set; }
    public decimal PrevPrice { get; set; } // Decimal for price
    public decimal NewPrice { get; set; }  // Decimal for price
    public string Company { get; set; }
    public string Color { get; set; }
    public string Category { get; set; }
}

}