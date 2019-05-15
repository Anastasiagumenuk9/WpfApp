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
    /// Логика взаимодействия для RemoveCar.xaml
    /// </summary>
    public partial class RemoveCar : Page
    {
        public RemoveCar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            using (Rend context = new Rend())
            {
                var car = context.Car.ToList()
                .Where(c => c.Id == Convert.ToInt32(TB.Text))
                .FirstOrDefault();

                context.Car.Remove(car);
                context.SaveChanges();
            }
            }
             catch
            {
                MessageBox.Show("Input Correct ID!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
