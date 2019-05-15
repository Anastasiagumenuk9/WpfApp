using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Drawing.Imaging;
using System.Drawing;
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

        }

        
        private string selectedFileName;
        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(TB1.Text != " " && TB2.Text != " " && TB3.Text != " ")
            {
                Bitmap bitMap = new Bitmap(selectedFileName);
                ImageFormat bmpFormat = bitMap.RawFormat;
                var imageToConvert = System.Drawing.Image.FromFile(selectedFileName);
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, bmpFormat);
                   
                    using (Model.Rend context = new Model.Rend())
                    {
                        Car cars = new Car();
                        cars.Name = TB1.Text;
                        //cars.Class = TB2.Text;
                        cars.Price = Convert.ToInt32(TB3.Text);
                        cars.Photo = ms.ToArray();
                        context.Car.Add(cars);
                        context.SaveChanges();

                        
                    }

                }

            }
            else
            {
                MessageBoxResult msr = MessageBox.Show("Input all information!");
            }



        }
    }
}
