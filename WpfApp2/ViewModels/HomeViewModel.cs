using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Windows.Input;
using WpfApp2.Repositories;
using System.Threading;
using System.IO;

namespace WpfApp2.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public List<VideosModel> videos { get; set; }


        public HomeViewModel()
        {

            // Retrieve data from SQL database and populate MyDataList
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM [Videos]";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            videos = new List<VideosModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                VideosModel data = new VideosModel
                {
                    ID = row["Id"].ToString(),
                    likes = Convert.ToInt32(row["Likes"]),
                    dislikes = Convert.ToInt32(row["Dislikes"]),
                    channel = row["Channel"].ToString(),
                    title = row["Title"].ToString(),
                    Thumbnail = row["ThumbNailURL"].ToString()
                };
                videos.Add(data);
            }

            reader.Close();
            connection.Close();
        }
    }
}
