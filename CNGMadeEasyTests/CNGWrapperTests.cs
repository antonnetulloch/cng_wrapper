using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CNGMadeEasy.Tests
{
    [TestClass()]
    public class CNGWrapperTests
    {
        private string keyName = "MyKey";

        [TestMethod()]
        public void EncryptTest()
        {
            //arrange
            string stringToEncrypt = "password";
            string encryptedString = "Updrxe9epasXAPOjsk8hjuKpbAhZ4FLryk8pDcGk5oibQLTgtE/vckPKy1LeeCzNlSwYx2DCpawh15sVERUGNV5LTw1xM14JgHY1NqpJ8M0C8IDjG9chR9A/h1QSMB1OvFmKVWFKM3UlTdzwtvRKYorPRTxmodiP+3EBwehlfrI=";

            //act
            var cng = new CNGWrapper();
            var result = cng.Encrypt(stringToEncrypt, keyName);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, encryptedString, false);
        }

        [TestMethod]
        public void DecryptTest()
        {
            //arrange
            string encryptedString = "Updrxe9epasXAPOjsk8hjuKpbAhZ4FLryk8pDcGk5oibQLTgtE/vckPKy1LeeCzNlSwYx2DCpawh15sVERUGNV5LTw1xM14JgHY1NqpJ8M0C8IDjG9chR9A/h1QSMB1OvFmKVWFKM3UlTdzwtvRKYorPRTxmodiP+3EBwehlfrI=";
            string expectedResult = "password";

            //act
            var cng = new CNGWrapper();
            var result = cng.Decrypt(encryptedString, keyName);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, expectedResult, false);
        }
    }
}