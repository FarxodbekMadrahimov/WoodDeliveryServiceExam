using Request.Domain.Entitites.Products;
using Request.Domain.Entitites.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Request.Domain.Entitites.deliver
{
public class Order
{
        [Key]
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }

    // Navigation properties
    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
}

}
