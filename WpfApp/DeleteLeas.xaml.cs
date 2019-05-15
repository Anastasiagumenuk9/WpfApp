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
    /// Логика взаимодействия для DeleteLeas.xaml
    /// </summary>
    public partial class DeleteLeas : Page
    {
        public DeleteLeas()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Rend context = new Rend())
                {
                    var leas = context.Lease.ToList()
                    .Where(c => c.Id == Convert.ToInt32(TB.Text))
                    .FirstOrDefault();

                    context.Lease.Remove(leas);
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
