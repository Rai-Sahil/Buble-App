using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WpfApp2.Repositories.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        UserRepository _userRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepository = new UserRepository();
        }

        [TestMethod()]
        public void UpdatetByIdTest()
        {
            // Set up test data
            string id = "6150c949d77d28467ff6c9f3"; // Replace with a valid ObjectId in your database
            string name = "John Doe";
            string username = "johndoe";
            string email = "johndoe@example.com";

            // Update the document with the test data
            _userRepository.UpdatetById(id, name, username, email);

            // Retrieve the updated document from the database
            var client = _userRepository.GetMongoClient();
            var database = client.GetDatabase("User-Auth");
            var collection = database.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var updatedDocument = collection.Find(filter).FirstOrDefault();

            // Assert that the document was updated correctly
            Assert.IsNotNull(updatedDocument);
            Assert.AreEqual(name, updatedDocument.GetValue("Firstname").AsString);
            Assert.AreEqual(username, updatedDocument.GetValue("Username").AsString);
            Assert.AreEqual(email, updatedDocument.GetValue("email").AsString);
        }

        [TestMethod()]
        public void ChangeUserPasswordTest()
        {
            // Set up test data
            string username = "johndoe"; // Replace with a valid username in your database
            string newPassword = "newpassword";

            // Change the user's password with the test data
            _userRepository.ChangeUserPassword(username, newPassword);

            // Retrieve the updated document from the database
            var client = _userRepository.GetMongoClient();
            var database = client.GetDatabase("User-Auth");
            var collection = database.GetCollection<BsonDocument>("User");
            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);
            var updatedDocument = collection.Find(filter).FirstOrDefault();

            // Assert that the password was updated correctly
            Assert.IsNotNull(updatedDocument);
            Assert.AreEqual(newPassword, updatedDocument.GetValue("Password").AsString);
        }
    }
}