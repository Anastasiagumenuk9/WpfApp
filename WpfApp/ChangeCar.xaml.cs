using Microsoft.Win32;
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
    /// Логика взаимодействия для ChangeCar.xaml
    /// </summary>
    public partial class ChangeCar : Page
    {
        public ChangeCar()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Model.Rend context = new Model.Rend())
                {
                    var cars = context.Car.ToList()

                    .Where(c => c.Id == Convert.ToInt32(TB.Text))
                    .FirstOrDefault();

                    if (TB1.Text.Trim() != "")
                    {
                        cars.Name = TB1.Text;
                    }
                    else if (TB2.Text.Trim() != "")
                    {
                        cars.CountOfSeets = Convert.ToInt32(TB2.Text);
                    }
                    else if (TB3.Text.Trim() != "")
                    {
                        cars.Conditioner = Convert.ToBoolean(TB3.Text);
                    }
                    else if (TB4.Text.Trim() != "")
                    {
                        cars.Petrol = Convert.ToBoolean(TB4.Text);
                    }
                    else if (TB5.Text.Trim() != "")
                    {
                        cars.ClassCarId = Convert.ToInt32(TB5.Text);
                    }
                    else if (TB6.Text.Trim() != "")
                    {
                        cars.TransmissionId = Convert.ToInt32(TB6.Text);
                    }
                    else if (TB7.Text.Trim() != "")
                    {
                        cars.Price = Convert.ToDouble(TB7.Text);
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

        

        private string selectedFileName;
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "";
            dlg.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                BitmapImage bmi = new BitmapImage();
                selectedFileName = dlg.FileName;
                bmi.BeginInit();
                bmi.CacheOption = BitmapCacheOption.OnLoad;
                bmi.UriSource = new Uri(selectedFileName);
                bmi.EndInit();
                I.Source = bmi;
            }
        }
    }

}
