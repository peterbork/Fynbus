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
using System.Windows.Shapes;

namespace Fynbus {
    /// <summary>
    /// Interaction logic for viewVehicles.xaml
    /// </summary>
    public partial class viewVehicles : Window {
        Controller.Controller _controller;
        public viewVehicles() {
            _controller = new Controller.Controller();
            InitializeComponent();
            ListVehicles.ItemsSource = _controller.ViewVehiclesFromCVR(MainWindow.selectedCompany);
        }
    }
}
