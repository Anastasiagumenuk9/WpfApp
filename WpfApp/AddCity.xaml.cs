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
    /// Логика взаимодействия для AddCity.xaml
    /// </summary>
    public partial class AddCity : Page
    {
        public AddCity()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                using (Model.Rend context = new Model.Rend())
                {
                    City city = new City();
                    city.Name = TB.Text;
                    city.CountryId = Convert.ToInt32(TB1.Text);

                    context.City.Add(city);
                    context.SaveChanges();


                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!");
            }
        }
    }
}
