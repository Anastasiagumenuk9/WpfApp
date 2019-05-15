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
    /// Логика взаимодействия для EditPromotion.xaml
    /// </summary>
    public partial class EditPromotion : Page
    {
        public EditPromotion()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Model.Rend context = new Model.Rend())
                {
                    var promotion = context.Promotion.ToList()

                    .Where(c => c.PromotionId == Convert.ToInt32(TB.Text))
                    .FirstOrDefault();

                    if (TB1.Text.Trim() != "")
                    {
                        promotion.Name = TB1.Text;
                    }
                    else if (TB2.Text.Trim() != "")
                    {
                        promotion.Description = TB2.Text;
                    }
                    else if (TB3.Text.Trim() != "")
                    {
                        promotion.Percent = Convert.ToInt32(TB3.Text);
                    }

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
