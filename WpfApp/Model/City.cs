using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp.Model
{
    public class City
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
     
        public virtual ICollection<Locations> Locations { get; set; }


    }
}
