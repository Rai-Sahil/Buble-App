using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Collections;
using WpfApp2.Objects;

namespace WpfApp2.Repositories
{
    public class VideoRepository : RepositoryBase, IVideosRepository
    {
        public List<VideosModel> GetAll()
        {
            SqlConnection connection = GetConnection();

            string query = "SELECT * FROM [Videos]";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            List<VideosModel> videos = new List<VideosModel>();

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
            connection.Dispose();

            return videos;
        }

        public VideosModel GetByVideoId(string videoId)
        {
            VideosModel video = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
               if (videoId != null)
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select * from [Videos] where Id=@id";
                    Guid videoGuid = Guid.Parse(videoId);
                    command.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = videoGuid;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            video = new VideosModel()
                            {
                                ID = reader[0].ToString(),
                                Thumbnail = reader[1].ToString(),
                                likes = Int32.Parse(reader[2].ToString()),
                                dislikes = Int32.Parse(reader[3].ToString()),
                                channel = reader[4].ToString(),
                                title = reader[5].ToString(),
                            };
                        }
                    }
                }
                else
                {
                    video = null;
                }

               
               connection.Close();
               connection.Dispose();
            }
            return video;
        }

        public void AddVideoInformationToMongoDB(string title, string channel)
        {
            MongoClient client = GetMongoClient();
            // Get the database object
            IMongoDatabase database = client.GetDatabase("Video");
            // Get the collection object
            IMongoCollection<BsonVideoObject> collection 
                = database.GetCollection<BsonVideoObject>("Videos");

            // Create a new document to insert into the collection
            BsonVideoObject document = new BsonVideoObject
            {
                Title = title,
                Channel = channel,
                Likes = 0,
                Dislikes = 0,
                Url = "https://d1m5sbyhb726tv.cloudfront.net/" + title + ".mp4",
                Comments = new ArrayList()
            };

            // Insert the document into the collection
            collection.InsertOne(document);

            Console.WriteLine("Document inserted successfully.");

        }
    }
}
