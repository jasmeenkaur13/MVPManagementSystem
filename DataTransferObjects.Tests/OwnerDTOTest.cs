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
    public class OwnerDTOTest
    {
        #region  Validate Owner Model Test Case

        #region  OwnerTypeValidation
        /// <summary>
        /// Owner Type is Required
        /// </summary>
        [TestMethod]
        public void ownerType_required()
        {
            // Arrange
            var model = new OwnerDTO();
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            Assert.AreEqual(result[0].ErrorMessage, "Please Enter the owner type");
            Assert.IsTrue(result[0].MemberNames.Contains("OwnerType"));
        }

        /// <summary>
        /// Owner Type is not P or D -- Private or Dealer
        /// </summary>
        [TestMethod]
        public void ownerType_eitherPorD()
        {
            // Arrange
            var model = new OwnerDTO() { OwnerType = "U" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            Assert.AreEqual(result[0].ErrorMessage, "Not a valid Owner type");
            Assert.IsTrue(result[0].MemberNames.Contains("OwnerType"));
        }

        /// <summary>
        /// Owner Type is P
        /// </summary>
        [TestMethod]
        public void ownerType_isP()
        {
            // Arrange
            var model = new OwnerDTO() { OwnerType = "P" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        /// <summary>
        /// Owner Type is D
        /// </summary>
        [TestMethod]
        public void ownerType_isD()
        {
            // Arrange
            var model = new OwnerDTO() { OwnerType = "D" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        /// <summary>
        /// Owner Type is p
        /// </summary>
        [TestMethod]
        public void ownerType_isp()
        {
            // Arrange
            var model = new OwnerDTO() { OwnerType = "p" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        /// <summary>
        /// Owner Type is d
        /// </summary>
        [TestMethod]
        public void ownerType_isd()
        {
            // Arrange
            var model = new OwnerDTO() { OwnerType = "d" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        #endregion

        #region NameFieldValidation

        /// <summary>
        /// Name should not contain digits
        /// </summary>
        [TestMethod]
        public void InvalidNameWithDigits()
        {
            // Arrange
            var model = new OwnerDTO() { Name = "123", OwnerType = "P" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            Assert.AreEqual(result[0].ErrorMessage, "Not a valid name");
            Assert.IsTrue(result[0].MemberNames.Contains("Name"));
        }

        /// <summary>
        /// Name should not contain special characters
        /// </summary>
        [TestMethod]
        public void InvalidNameWithSpecialCharacters()
        {
            // Arrange
            var model = new OwnerDTO() { Name = "!@#", OwnerType = "P" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            Assert.AreEqual(result[0].ErrorMessage, "Not a valid name");
            Assert.IsTrue(result[0].MemberNames.Contains("Name"));
        }

        /// <summary>
        /// Name with characters and space
        /// </summary>
        [TestMethod]
        public void ValidNameWithCharacters()
        {
            // Arrange
            var model = new OwnerDTO() { Name = "Jasmeen Kaur", OwnerType = "P" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }
        #endregion
        #endregion
    }
}
