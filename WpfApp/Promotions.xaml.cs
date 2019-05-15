using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Promotions.xaml
    /// </summary>
    public partial class Promotions : Page
    {
        public Promotions()
        {
            InitializeComponent();
            using (Model.Rend context = new Model.Rend())
            {

                var promotions = context.Promotion.ToList();
               


                foreach (var c in promotions)
                {
                    LB.Items.Add(c);

                }
               

            }
            
        }
    }
}
