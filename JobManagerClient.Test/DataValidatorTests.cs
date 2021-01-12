using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JobManagerClient.Test
{
    [TestClass]
    public class DataValidatorTests
    {

        [TestMethod]
        public void UppercaseLicensePlateCorrectly()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var actual = dataValidator.correctLicensePlate("aaa123");
            var expected = "AAA-123";

            //Act and assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LicensePlate_WithoutHyphen_ShouldReturnTrue()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var licensePlate = dataValidator.correctLicensePlate("aaa123");

            //Act and assert
            Assert.IsTrue(dataValidator.checkLicensePlate(licensePlate));
        }

        [TestMethod]
        public void LicensePlate_WithHyphen_ShouldReturnTrue()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var licensePlate = "aaa-123";

            //Act and assert
            Assert.IsTrue(dataValidator.checkLicensePlate(licensePlate));
        }

        [TestMethod]
        public void LicensePlate_CorrectLengthTooManyCharacters_ShouldReturnFalse()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var licensePlate = "aaa-a23";

            //Act and assert
            Assert.IsFalse(dataValidator.checkLicensePlate(licensePlate));
        }

        [TestMethod]
        public void LicensePlate_CorrectLengthTooManyNumbers_ShouldReturnFalse()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var licensePlate = "aa4-123";

            //Act and assert
            Assert.IsFalse(dataValidator.checkLicensePlate(licensePlate));
        }

       

    }
}
