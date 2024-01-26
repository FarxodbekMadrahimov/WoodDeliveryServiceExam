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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Message { get; set; }

    }

}
