using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
using WpfApp2.CustomControls;
using WpfApp2.Repositories;
using WpfApp2.ViewModels;
using WpfApp2.Views.Pages;

namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();

            DataContext = new CustomerViewModel();

            UserDisplayFrame.NavigationService.Navigate(new AllUsersView());
        }
    }
}
