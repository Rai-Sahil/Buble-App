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

namespace WpfApp2.CustomControls
{
    /// <summary>
    /// Interaction logic for FileDetails.xaml
    /// </summary>
    public partial class FileDetails : UserControl
    {
        public FileDetails()
        {
            InitializeComponent();
        }



        public int FileName
        {
            get { return (int)GetValue(FilenameProperty); }
            set { SetValue(FilenameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Filename.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilenameProperty =
            DependencyProperty.Register("Filename", typeof(int), typeof(FileDetails));



        public string FileSize
        {
            get { return (string)GetValue(FileSizeProperty); }
            set { SetValue(FileSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileSizeProperty =
            DependencyProperty.Register("FileSize", typeof(string), typeof(FileDetails));



        public int UploadProgress
        {
            get { return (int)GetValue(UploadProgressProperty); }
            set { SetValue(UploadProgressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UploadProgress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UploadProgressProperty =
            DependencyProperty.Register("UploadProgress", typeof(int), typeof(FileDetails));



        public int UploadSpeed
        {
            get { return (int)GetValue(UploadSpeedProperty); }
            set { SetValue(UploadSpeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UploadSpeed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UploadSpeedProperty =
            DependencyProperty.Register("UploadSpeed", typeof(int), typeof(FileDetails));


    }
}
