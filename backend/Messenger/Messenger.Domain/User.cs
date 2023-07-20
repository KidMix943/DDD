using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Domain
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Login { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string City { get; set; } = "";
    }
}
