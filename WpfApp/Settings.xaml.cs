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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
      
        public Settings()
        {
            
            InitializeComponent();
          

            CB.Items.Add("Car");
            CB.Items.Add("City");
            CB.Items.Add("Country");
            CB.Items.Add("Locations");
            CB.Items.Add("User");
            CB.Items.Add("Promotion");
            CB.Items.Add("PromotionCar");



        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Content = null;
            using (Rend context = new Rend())
            {


                if (CB.SelectedValue.ToString() == "Car")
                {
                    LB.IsEnabled = true;
                    LB.Visibility = Visibility.Visible;
                    LB1.IsEnabled = false;
                    LB1.Visibility = Visibility.Hidden;
                    LB2.IsEnabled = false;
                    LB2.Visibility = Visibility.Hidden;
                    LB3.IsEnabled = false;
                    LB3.Visibility = Visibility.Hidden;
                    LB4.IsEnabled = false;
                    LB4.Visibility = Visibility.Hidden;
                    LB5.IsEnabled = false;
                    LB5.Visibility = Visibility.Hidden;
                    LB6.IsEnabled = false;
                    LB6.Visibility = Visibility.Hidden;

                    var cars = context.Car.ToList();
                    LB.ItemsSource = cars;

                }
                else if (CB.SelectedValue.ToString() == "City")
                {
                    LB1.IsEnabled = true;
                    LB1.Visibility = Visibility.Visible;
                    LB.IsEnabled = false;
                    LB.Visibility = Visibility.Hidden;
                    LB2.IsEnabled = false;
                    LB2.Visibility = Visibility.Hidden;
                    LB3.IsEnabled = false;
                    LB3.Visibility = Visibility.Hidden;
                    LB4.IsEnabled = false;
                    LB4.Visibility = Visibility.Hidden;
                    LB5.IsEnabled = false;
                    LB5.Visibility = Visibility.Hidden;
                    LB6.IsEnabled = false;
                    LB6.Visibility = Visibility.Hidden;

                    var cities = context.City.ToList();
                    LB1.ItemsSource = cities;
                }
                else if (CB.SelectedValue.ToString() == "Country")
                {
                    LB2.IsEnabled = true;
                    LB2.Visibility = Visibility.Visible;
                    LB.IsEnabled = false;
                    LB.Visibility = Visibility.Hidden;
                    LB1.IsEnabled = false;
                    LB1.Visibility = Visibility.Hidden;
                    LB3.IsEnabled = false;
                    LB3.Visibility = Visibility.Hidden;
                    LB4.IsEnabled = false;
                    LB4.Visibility = Visibility.Hidden;
                    LB5.IsEnabled = false;
                    LB5.Visibility = Visibility.Hidden;
                    LB6.IsEnabled = false;
                    LB6.Visibility = Visibility.Hidden;

                    var countries = context.Country.ToList();
                    LB2.ItemsSource = countries;
                }
                else if (CB.SelectedValue.ToString() == "Locations")
                {
                    LB3.IsEnabled = true;
                    LB3.Visibility = Visibility.Visible;
                    LB.IsEnabled = false;
                    LB.Visibility = Visibility.Hidden;
                    LB1.IsEnabled = false;
                    LB1.Visibility = Visibility.Hidden;
                    LB2.IsEnabled = false;
                    LB2.Visibility = Visibility.Hidden;
                    LB4.IsEnabled = false;
                    LB4.Visibility = Visibility.Hidden;
                    LB5.IsEnabled = false;
                    LB5.Visibility = Visibility.Hidden;
                    LB6.IsEnabled = false;
                    LB6.Visibility = Visibility.Hidden;

                    var locations = context.Location.ToList();
                    LB3.ItemsSource = locations;
                }
                else if (CB.SelectedValue.ToString() == "User")
                {
                    LB4.IsEnabled = true;
                    LB4.Visibility = Visibility.Visible;
                    LB.IsEnabled = false;
                    LB.Visibility = Visibility.Hidden;
                    LB1.IsEnabled = false;
                    LB1.Visibility = Visibility.Hidden;
                    LB3.IsEnabled = false;
                    LB3.Visibility = Visibility.Hidden;
                    LB2.IsEnabled = false;
                    LB2.Visibility = Visibility.Hidden;
                    LB5.IsEnabled = false;
                    LB5.Visibility = Visibility.Hidden;
                    LB6.IsEnabled = false;
                    LB6.Visibility = Visibility.Hidden;

                    var users = context.User.ToList();
                    LB4.ItemsSource = users;
                }
                else if (CB.SelectedValue.ToString() == "Promotion")
                {
                    LB5.IsEnabled = true;
                    LB5.Visibility = Visibility.Visible;
                    LB1.IsEnabled = false;
                    LB1.Visibility = Visibility.Hidden;
                    LB.IsEnabled = false;
                    LB.Visibility = Visibility.Hidden;
                    LB2.IsEnabled = false;
                    LB2.Visibility = Visibility.Hidden;
                    LB3.IsEnabled = false;
                    LB3.Visibility = Visibility.Hidden;
                    LB4.IsEnabled = false;
                    LB4.Visibility = Visibility.Hidden;
                    LB6.IsEnabled = false;
                    LB6.Visibility = Visibility.Hidden;

                    var promotions = context.Promotion.ToList();
                    LB5.ItemsSource = promotions;
                }
                else if (CB.SelectedValue.ToString() == "PromotionCar")
                {
                    LB6.IsEnabled = true;
                    LB6.Visibility = Visibility.Visible;
                    LB1.IsEnabled = false;
                    LB1.Visibility = Visibility.Hidden;
                    LB.IsEnabled = false;
                    LB.Visibility = Visibility.Hidden;
                    LB2.IsEnabled = false;
                    LB2.Visibility = Visibility.Hidden;
                    LB3.IsEnabled = false;
                    LB3.Visibility = Visibility.Hidden;
                    LB4.IsEnabled = false;
                    LB4.Visibility = Visibility.Hidden;
                    LB5.IsEnabled = false;
                    LB5.Visibility = Visibility.Hidden;

                    var promotioncar = context.PromotionCar.ToList();
                    LB6.ItemsSource = promotioncar;
                }


            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CB.SelectedValue.ToString() == "Car")
            {
                MessageBoxResult result = MessageBox.Show(LB.SelectedIndex.ToString());
            }
            else if (CB.SelectedValue.ToString() == "City")
            {
                MessageBoxResult result = MessageBox.Show(LB1.SelectedIndex.ToString());
            }
            else if (CB.SelectedValue.ToString() == "Country")
            {
                MessageBoxResult result = MessageBox.Show(LB2.SelectedIndex.ToString());
            }
            else if (CB.SelectedValue.ToString() == "Locations")
            {
                MessageBoxResult result = MessageBox.Show(LB3.SelectedIndex.ToString());
            }
            else if (CB.SelectedValue.ToString() == "User")
            {
                MessageBoxResult result = MessageBox.Show(LB4.SelectedIndex.ToString());
            }
            else if (CB.SelectedValue.ToString() == "Promotion")
            {
                MessageBoxResult result = MessageBox.Show(LB5.SelectedIndex.ToString());
            }
            else if (CB.SelectedValue.ToString() == "PromotionCar")
            {
                MessageBoxResult result = MessageBox.Show(LB6.SelectedIndex.ToString());
            }

        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CB.SelectedValue.ToString() == "Car")
            {
                Frame.Content = new AddCar();
            }
            if (CB.SelectedValue.ToString() == "City")
            {
                Frame.Content = new AddCity();
            }
            if (CB.SelectedValue.ToString() == "Country")
            {
                Frame.Content = new AddCountry();
            }
            if (CB.SelectedValue.ToString() == "Locations")
            {
                Frame.Content = new AddLocation();
            }
            if (CB.SelectedValue.ToString() == "User")
            {
                Frame.Content = new AddUser();
            }
            if (CB.SelectedValue.ToString() == "Promotion")
            {
                Frame.Content = new AddPromotion();
            }
            if (CB.SelectedValue.ToString() == "PromotionCar")
            {
                Frame.Content = new AddPromotionCar();
            }
            else if(CB.SelectedValue == null)
            {
                MessageBoxResult msr = MessageBox.Show("Choose Table! ");
            }
           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {



            if (CB.SelectedValue.ToString() == "Car")
            {
                Frame.Content = new RemoveCar();


            }
            if (CB.SelectedValue.ToString() == "City")
            {
                Frame.Content = new RemoveCity();
            }
            if (CB.SelectedValue.ToString() == "Country")
            {
                Frame.Content = new RemoveCountry();
            }
            if (CB.SelectedValue.ToString() == "Locations")
            {
                Frame.Content = new RemoveLocation();
            }
            if (CB.SelectedValue.ToString() == "User")
            {
                Frame.Content = new RemoveUser();
            }
            if (CB.SelectedValue.ToString() == "Promotion")
            {
                Frame.Content = new RemovePromotion();
            }
            if (CB.SelectedValue.ToString() == "PromotionCar")
            {
                Frame.Content = new RemovePromotionCar();
            }
            else if (CB.SelectedValue == null)
            {
                MessageBoxResult msr = MessageBox.Show("Choose Table! ");
            }



        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (CB.SelectedValue.ToString() == "Car")
            {
                Frame.Content = new ChangeCar();


            }

            if (CB.SelectedValue.ToString() == "City")
            {
                Frame.Content = new EditCity();
            }

            if (CB.SelectedValue.ToString() == "Country")
            {
                Frame.Content = new EditCountry();
            }
            if (CB.SelectedValue.ToString() == "Locations")
            {
                Frame.Content = new EditLocation();
            }
            if (CB.SelectedValue.ToString() == "User")
            {
                Frame.Content = new EditUser();
            }
            if (CB.SelectedValue.ToString() == "Promotion")
            {
                Frame.Content = new EditPromotion();
            }
            if (CB.SelectedValue.ToString() == "PromotionCar")
            {
                Frame.Content = new EditPromotionCar();
            }
            else if (CB.SelectedValue == null)
            {
                MessageBoxResult msr = MessageBox.Show("Choose Table! ");
            }
        }
    }
    }

