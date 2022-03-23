using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionUserRegistra;
namespace ExceptionUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodExcep()
        {

            string excepted = "true";
            var actual = UserRegistration.ValidateFirstName("Saurav");
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("FirstName_ReturnFalse")]
        public void GivenFirstNameShouldReturnFalse()
        {
            string excepted = "false";
            var actual = UserRegistration.ValidateFirstName("Sa");
            Assert.AreEqual(excepted, actual);
            var actual1 = UserRegistration.ValidateFirstName("saurav");
            Assert.AreEqual(excepted, actual1);
        }
        [TestMethod]
        [TestCategory("LastName_ReturnTrue")]
        public void GivenLastNameShouldReturnTrue()
        {
            string excepted = "true";
            var actual = UserRegistration.ValidateLastName("Kumar");
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("LastName_ReturnFalse")]
        public void GivenLastNameShouldReturnFalse()
        {
            string excepted = "false";
            var actual = UserRegistration.ValidateLastName("Ka");
            Assert.AreEqual(excepted, actual);
            var actual1 = UserRegistration.ValidateLastName("kumar");
            Assert.AreEqual(excepted, actual1);
        }
        [TestMethod]
        [TestCategory("EmailId_ReturnTrue")]
        public void GivenEmailIDshouldReturnTrue()
        {
            string excepted = "true";
            var actual = UserRegistration.ValidateEmailID("saurav@gmail.co.in");
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("EmailId_ReturnFalse")]
        public void GivenEmailIDShouldReturnFalse()
        {
            string excepted = "false";
            var actual = UserRegistration.ValidateEmailID("saurav.kr@g.in");
            Assert.AreEqual(excepted, actual);
            var actual1 = UserRegistration.ValidateEmailID(".kr@gmail.com.in");
            Assert.AreEqual(excepted, actual1);
        }
        [TestMethod]
        [TestCategory("MobileNumber_ReturnTrue")]
        public void GivenMobileNumberShouldReturnTrue()
        {
            string excepted = "true";
            var actual = UserRegistration.ValidateMobileNumber("91 7067845485");
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("MobileNumber_ReturnFalse")]
        public void GivenMobileNumberShouldReturnFalse()
        {
            string excepted = "false";
            var actual = UserRegistration.ValidateMobileNumber("7067845485");
            Assert.AreEqual(excepted, actual);
            var actual1 = UserRegistration.ValidateMobileNumber("23 7067845485");
            Assert.AreEqual(excepted, actual1);
            var actual2 = UserRegistration.ValidateMobileNumber("91 70678454858");
            Assert.AreEqual(excepted, actual2);
        }
        [TestMethod]
        [TestCategory("Password_ReturnTrue")]
        public void GivenPasswordShouldReturnTrue()
        {
            string excepted = "true";
            var actual = UserRegistration.ValidatePassword("SauGav76@#$");
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("Password_ReturnFalse")]
        public void GivenPasswordShouldReturnFalse()
        {
            string excepted = "false";
            var actual = UserRegistration.ValidatePassword("S9a@#$j");
            Assert.AreEqual(excepted, actual);
        }
    }
    
}