﻿using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp2.ViewModels;

namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for UploadView.xaml
    /// </summary>
    public partial class UploadView : UserControl
    {
        private string videoFilePath = "";
        UploadViewModel viewModel;

        public UploadView()
        {
            viewModel = new UploadViewModel();
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            // Show a file dialog to select the video file
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Video Files (*.mp4;*.mkv;*.avi)|*.mp4;*.mkv;*.avi|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Save the selected file path and display it in the TextBlock
                videoFilePath = openFileDialog.FileName;
                filePathTextBlock.Text = videoFilePath;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            // Check if a video file has been selected
            if (string.IsNullOrEmpty(videoFilePath) && string.IsNullOrEmpty(KeyName.Text))
            {
                System.Windows.MessageBox.Show("Please select a video file to upload.");
                return;
            }

            viewModel.Upload_To_Cloud(KeyName.Text, videoFilePath);

            // TODO: Upload the fileBytes to the server using a web API or other mechanism
            Console.WriteLine("File uploaded successfully.");
        }
    }
}
