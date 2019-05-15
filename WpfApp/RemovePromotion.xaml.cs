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
    /// Логика взаимодействия для RemovePromotion.xaml
    /// </summary>
    public partial class RemovePromotion : Page
    {
        public RemovePromotion()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Rend context = new Rend())
                {
                    var promotion = context.Promotion.ToList()
                    .Where(c => c.PromotionId == Convert.ToInt32(TB.Text))
                    .FirstOrDefault();

                    context.Promotion.Remove(promotion);
                    context.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Input Correct ID!");
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
