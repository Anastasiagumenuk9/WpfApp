using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp
{
    public class ConcretePrice : IPrice
    {

        string car;
        int d;

        public ConcretePrice(string _car, int _d)
        {
            car = _car;
            d = _d;

        }
        
           
        public override double GetPrice()
        {
            double sum=0;
            bool k = false;

            using (Model.Rend context = new Model.Rend())
            {

              
                var cars = context.Car.ToList();

                foreach (Car c in cars)

                {
                    if (c.Name == car)
                    {
                        k = true;
                        sum = c.Price;
                        break;
                        
                        
                    }
                    else
                    {
                        k = false;

                       
                    }

                }
               
                if(k == true)
                {
                    return sum*d;
                }
                else
                {
                    return 0;
                }
            }
            
            
        }
    }
}
