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

        [TestMethod]
        public void TrimNameCorrectlyOnePlusSpace()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var actual = dataValidator.correctName(" Correct Name ");
            var expected = "Correct Name";

            //Act and assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrimNameCorrectlyManyPlusSpaces()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var actual = dataValidator.correctName("      Correct Name                  ");
            var expected = "Correct Name";

            //Act and assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UppercaseNameCorrectlyTwoParts()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var actual = dataValidator.correctName("correct name");
            var expected = "Correct Name";

            //Act and assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UppercaseNameCorrectlyManyParts()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var actual = dataValidator.correctName("looks like someone has a really long name");
            var expected = "Looks Like Someone Has A Really Long Name";

            //Act and assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Name_WithoutSpace_ShouldReturnFalse()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var name = "nospace";

            //Act and assert
            Assert.IsFalse(dataValidator.checkName(name));
        }

        [TestMethod]
        public void Name_WithOneSpace_ShouldReturnTrue()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var name = "is space";

            //Act and assert
            Assert.IsTrue(dataValidator.checkName(name));
            //Act and assert
        }

        [TestMethod]
        public void Name_WithSeveralSpaces_ShouldReturnTrue()
        {
            //Arrange
            DataValidator dataValidator = new DataValidator();
            var name = "looks like someone has a really long name";

            //Act and assert
            Assert.IsTrue(dataValidator.checkName(name));
            //Act and assert
        }

    }
}
