using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models.Tests
{
    [TestClass()]
    public class RecoverPasswordModelTests
    {
        [TestMethod()]
        public void SendNewPasswordToUserTest()
        {
            string email = "user@gmail.com";
            string emailTemplate = "<html><body><h1>Your new password is: 123456</h1></body></html>";

            try
            {
                // Call the function to send the email
                RecoverPasswordModel.SendNewPasswordToUser(email, emailTemplate);

                // If no exception is thrown, the email was sent successfully
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                // If an exception is thrown, the email was not sent
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void GenerateRandomPasswordTest()
        {
            // Generate a random password
            string password = RecoverPasswordModel.GenerateRandomPassword();

            // Assert that the password has a length of 8
            Assert.AreEqual(8, password.Length);

            // Assert that the password contains only the allowed characters
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=";
            Assert.IsTrue(password.All(c => allowedChars.Contains(c)));
        }
    }
}