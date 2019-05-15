using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Strategy
{
    class WithoutPromotion : Strategy
    {
        double pr;

        public WithoutPromotion(double _pr)
        {
        pr = _pr;

        }
        public override double Price()
        {

            return pr;

        }
    }
}
