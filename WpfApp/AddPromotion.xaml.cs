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
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AddPromotion.xaml
    /// </summary>
    public partial class AddPromotion : Page
    {
        public AddPromotion()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Model.Rend context = new Model.Rend())
                {
                    Promotion promotion = new Promotion();
                    promotion.Name = TB.Text;
                    promotion.Description = (TB1.Text);
                    promotion.Percent = Convert.ToInt32(TB2.Text);

                    context.Promotion.Add(promotion);
                    context.SaveChanges();


                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
