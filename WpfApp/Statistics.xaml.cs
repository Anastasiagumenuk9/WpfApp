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
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        int Uid;
        public Statistics( int _Uid)
        {
            Uid = _Uid;
            InitializeComponent();

            CB.Items.Add("By Price");
            CB.Items.Add("By ID");
            CB.Items.Add("By Car");


            using(Rend context = new Rend())
            {
                var leases = context.Lease.ToList().Where(p=>p.UserId==Uid);

                LB.ItemsSource = leases;
            }
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (Rend context = new Rend())
            {


                if (CB.SelectedValue.ToString() == "By Price")
                {
                    var orders = context.Lease.ToList().Where(p=>p.UserId == Uid).OrderBy(c => c.Price);
                    LB.ItemsSource = orders;
                }
                else if(CB.SelectedValue.ToString() == "By ID")
                {
                    var orders = context.Lease.ToList().Where(p => p.UserId == Uid).OrderBy(c => c.Id);
                    LB.ItemsSource = orders;
                }
                else if (CB.SelectedValue.ToString() == "By Car")
                {
                    var orders = context.Lease.ToList().Where(p => p.UserId == Uid).OrderBy(c => c.CarName);
                    LB.ItemsSource = orders;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                Frame.Content = new DeleteLeas();


            
        }
    }
}
