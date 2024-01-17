using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Domain.Entitites.Products
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public int? UserId { get; set; }

        
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

}
