using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp.Model
{
    public class Car
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
      
        
        public int CountOfSeets { get; set; }
       
        public bool Conditioner { get; set; }
        public bool Petrol { get; set; }
        public double Price { get; set; }
        public byte[] Photo { get; set; }


        public int ClassCarId { get; set; }
        public int TransmissionId { get; set; }
        public List<PromotionCar> PromotionCar{ get; set; }
        public ClassCar ClassCar { get; set; }
        public Transmission Transmission { get; set; }

    }
}
