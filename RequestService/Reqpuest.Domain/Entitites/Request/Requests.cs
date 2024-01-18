using Request.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Domain.Entitites.Request
{
    public class Requesting
    {
        [Key]
        public int RequestId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }

        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }
    }

}
