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
using Fynbus.Controller;

namespace Fynbus {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Controller.Controller _controller;
        public static string selectedCompany = "";
        public MainWindow() {
            _controller = new Controller.Controller();
            InitializeComponent();
            ListCompanies.ItemsSource = _controller.ViewAllCompanies();
            foreach (Model.TrafficCompany _TrafficCompany in _controller.ViewAllTrafficCompanies())
	        {
                ComboBoxTrafficCompany.Items.Add(_TrafficCompany.Name);
	        }
            ComboBoxTrafficCompany.Items.Add("Vis alle");
        }

        private void ComboBoxTrafficCompany_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ComboBoxTrafficCompany.SelectedIndex == ComboBoxTrafficCompany.Items.Count - 1) {
                ListCompanies.ItemsSource = _controller.ViewAllCompanies();
            }
            else {
                ListCompanies.ItemsSource = _controller.ViewAllCompaniesFromTrafficCompany(ComboBoxTrafficCompany.SelectedIndex + 1);
            }
        }

        private void ComboBoxTrafficCompany_loaded(object sender, RoutedEventArgs e) {
            ComboBoxTrafficCompany.SelectedIndex = ComboBoxTrafficCompany.Items.Count - 1;
        }

        private void ListCompanies_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            
            
            viewVehicles window = new viewVehicles();
            window.Show();

        }
    }
}
