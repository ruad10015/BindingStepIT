using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; OnPropertyChanged(); }
        }

        //public ObservableCollection<Car> Cars { get; set; }

        private ObservableCollection<Car> cars;

        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set { cars = value; OnPropertyChanged(); }
        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Car = new Car
            {
                Id = 1,
                Model = "AMG",
                Vendor = "Mercedes",
                Year = 2020
            };

            Cars = new ObservableCollection<Car>
            {
                new Car
                {
                    Id=1,
                     Model="E-300de",
                      Vendor="Mercedes",
                       Year=2021
                },
                new Car
                {
                    Id=2,
                     Model="Lancer",
                      Vendor="Mitsubishi",
                       Year=2020
                },
                new Car
                {
                    Id=3,
                     Model="Prado",
                      Vendor="Toyota",
                       Year=2018
                }
            };
        }
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["mainColor"] = this.Resources["secondColor"];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Car = new Car
            //{
            //    Id = 2,
            //    Year = 2010,
            //    Model = "528",
            //    Vendor = "BMW"
            //};

            Car.Model = "E-220";
        }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged(); }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Cars = new ObservableCollection<Car>
            {
                  new Car
                {
                    Id=55,
                     Model="E-300de",
                      Vendor="Mercedes",
                       Year=2021
                },
                new Car
                {
                    Id=88,
                     Model="Lancer",
                      Vendor="Mitsubishi",
                       Year=2020
                }
            };


            //Cars.Add(new Car
            //{
            //    Id=5,
            //     Model="Range Rover",
            //      Vendor="Land Rover",
            //       Year=2023
            //});
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ////Cars.Remove(SelectedCar);   
            var window = new InfoWindow();
            window.InfoCar = SelectedCar;
            window.ShowDialog();
        }
    }
}
