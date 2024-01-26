using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Products;
using Request.Domain.Entitites.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Request.Domain.Entitites.Users
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string  PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? ProductId { get; set; }


        // Navigation properties
        
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }

}
