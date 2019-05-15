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
    /// Логика взаимодействия для EditCity.xaml
    /// </summary>
    public partial class EditCity : Page
    {
        public EditCity()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Model.Rend context = new Model.Rend())
                {
                    var city = context.City.ToList()

                    .Where(c => c.Id == Convert.ToInt32(TB.Text))
                    .FirstOrDefault();

                    if (TB1.Text.Trim() != "")
                    {
                        city.Name = TB1.Text;
                    }
                    else if (TB2.Text.Trim() != "")
                    {
                        city.CountryId = Convert.ToInt32(TB2.Text);
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
