using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Driver : BaseDecorator
    {
        bool? dr;
        int d;
        public Driver(bool? _dr, int _d)
        {
            dr = _dr;
            d = _d;
        }

        public override double GetPrice()
        {
            if(dr == true)
            {
                return IPrice.GetPrice() + (20*d);
            }
            else
            {
                return IPrice.GetPrice();
            }
            
        }
    }
}
