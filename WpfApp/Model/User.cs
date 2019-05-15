using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp.Model
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Login { get; set; }
        [MaxLength(50)]
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<Lease> Lease { get; set; }
    }
}
