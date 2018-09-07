using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataTransferObjects.Tests
{
    /// <summary>
    /// Owner DTO Test class model validations
    /// </summary>
    [TestClass]
    public class AdvertisedCarDTOTest
    {
        #region  Validate Car Model Test Case

        #region YearFieldValidation
        
        /// <summary>
        /// Year is Required
        /// </summary>
        [TestMethod]
        public void Year_required()
        {
            // Arrange
            var model = new AdvertisedCarDTO();
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            Assert.AreEqual(result[0].ErrorMessage, "Year can not be Empty");
            Assert.IsTrue(result[0].MemberNames.Contains("Year"));
        }

        /// <summary>
        /// alphabets in Year
        /// </summary>
        [TestMethod]
        public void Year_withCharacters()
        {
            // Arrange
            var model = new AdvertisedCarDTO() { Year = "U"};
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            Assert.AreEqual(result[0].ErrorMessage, "Please Enter Digits");
            Assert.IsTrue(result[0].MemberNames.Contains("Year"));
        }

        /// <summary>
        /// year with more than 4 digits
        /// </summary>
        [TestMethod]
        public void Year_max4digits()
        {
            // Arrange
            var model = new AdvertisedCarDTO() { Year = "12345" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            Assert.AreEqual(result[0].ErrorMessage, "Year can be of max 4 digits");
            Assert.IsTrue(result[0].MemberNames.Contains("Year"));
        }

        #endregion

        #region Make
        /// <summary>
        /// Make is Required
        /// </summary>
        [TestMethod]
        public void Make_required()
        {
            // Arrange
            var model = new AdvertisedCarDTO();
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Make can not be Empty")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("Make"));
        }

        /// <summary>
        /// Make is empty
        /// </summary>
        [TestMethod]
        public void MakeEmpty()
        {
            // Arrange
            var model = new AdvertisedCarDTO() { Make = ""};
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Make can not be Empty")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("Make"));
        }

        #endregion

        #region Model
        /// <summary>
        /// Model is Required
        /// </summary>
        [TestMethod]
        public void Model_required()
        {
            // Arrange
            var model = new AdvertisedCarDTO();
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Model can not be Empty")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("Model"));
        }

        /// <summary>
        /// Model is empty
        /// </summary>
        [TestMethod]
        public void ModelEmpty()
        {
            // Arrange
            var model = new AdvertisedCarDTO() { Model = "" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Model can not be Empty")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("Model"));
        }

        #endregion

        /// <summary>
        /// valid values test case
        /// </summary>
        [TestMethod]
        public void ValidValues()
        {
            // Arrange
            var model = new AdvertisedCarDTO() { AdvertisedPriceType = "eCg", Make ="asd", Year = "1234", Model = "sdqs" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

       
        #endregion
    }
}
