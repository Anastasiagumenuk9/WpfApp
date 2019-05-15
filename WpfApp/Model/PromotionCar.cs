using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
  
    public class PromotionCar
    {
        public int Id { get; set; }

        public int PromotionId { get; set; }
        public int CarId { get; set; }

        public Car Car { get; set; }
        public Promotion Promotion { get; set; }
    }
}
