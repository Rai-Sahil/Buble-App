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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WpfApp2.CustomControls;
using WpfApp2.Repositories;
using System.ComponentModel;
using System.Data.SqlClient;
using WpfApp2.ViewModels;
using System.Runtime.Remoting.Messaging;

namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            DataContext = new HomeViewModel();
            frame.NavigationService.Navigate(new Page1());
        }

    }
}
