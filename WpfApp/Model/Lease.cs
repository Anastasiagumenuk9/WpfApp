using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp.Model
{
    public class Lease
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd{ get; set; }
        public double Price { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }


    }
}
