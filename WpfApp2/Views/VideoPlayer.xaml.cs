using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp2.Repositories;
using WpfApp2.ViewModels;

namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        public Page2(string id)
        {
            InitializeComponent();

            DataContext = new HomeViewModel();

            string html = "<html><head>";
            html += "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\" />";
            html += "<iframe id='video' src='https://d1m5sbyhb726tv.cloudfront.net/Ron%20Swanson,%20A%20Lifestyle%20(Vol.%20III)%20_%20Parks%20and%20Recreation.mp4' width='600' height='300' frameborder='0' allowfullscreen></iframe>";
            html += "</head></html>";

            //browser.NavigateToString(html);
            media.Source = new Uri("C:\\Users\\raisa\\OneDrive\\Desktop\\Ron Swanson, A Lifestyle (Vol. III) _ Parks and Recreation.mp4");

        }


       
    }
}
