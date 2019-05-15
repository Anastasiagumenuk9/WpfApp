using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Model;

namespace WpfApp.Strategy
{
    class WithPromotion : Strategy
    {

        double pr;
        double per;

        public WithPromotion(double _pr, double _per)
        {
            pr = _pr;
            per = _per;

        }
        public override double Price()
        {
            
            return (pr * ((100 - per) / 100));

        }
    }
}
