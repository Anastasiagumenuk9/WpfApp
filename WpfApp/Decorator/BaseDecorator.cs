using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class BaseDecorator : IPrice
    {
        public IPrice IPrice { protected get; set; }
        public double n { get; set; }


        public void SetComponent(IPrice iPrice)
        {
            this.IPrice = iPrice;


        }

        public override double GetPrice()
        {
            if (IPrice != null)

                return IPrice.GetPrice();
            else
                return 0;


        }
    }
}
