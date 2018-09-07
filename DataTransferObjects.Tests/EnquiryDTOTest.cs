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
    public class EnquiryDTOTest
    {
        #region  Validate Enquiry Model Test Case

        #region  EmailValidation

        /// <summary>
        /// Owner Type is not P or D -- Private or Dealer
        /// </summary>
        [TestMethod]
        public void EmailInvaidNotProperFormat()
        {
            // Arrange
            var model = new EnquiryDTO() { Email = "asgdf"};
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Please Enter a valid email")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("Email"));
        }

        /// <summary>
        /// Owner Type is not P or D -- Private or Dealer
        /// </summary>
        [TestMethod]
        public void EmailInvaidNumericFormat()
        {
            // Arrange
            var model = new EnquiryDTO() { Email = "1234" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Please Enter a valid email")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("Email"));
        }

        /// <summary>
        /// Owner Type is not P or D -- Private or Dealer
        /// </summary>
        [TestMethod]
        public void EmailInvaidSpecialCharacters()
        {
            // Arrange
            var model = new EnquiryDTO() { Email = "@3#4" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Please Enter a valid email")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("Email"));
        }
        #endregion

        #region PhoneNumber

        /// <summary>
        /// Owner Type is P
        /// </summary>
        [TestMethod]
        public void PhoneInvaidNotProperFormat()
        {
            // Arrange
            var model = new EnquiryDTO() { PhoneNumber = "asgdf" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Please enter a valid phone number")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("PhoneNumber"));
        }

        /// <summary>
        /// Owner Type is P
        /// </summary>
        [TestMethod]
        public void PhoneInvaidspecialCharacters()
        {
            // Arrange
            var model = new EnquiryDTO() { PhoneNumber = "@123as" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsFalse(valid);
            var match = result.Where(x => x.ErrorMessage.Equals("Please enter a valid phone number")).FirstOrDefault();
            Assert.IsTrue(match != null);
            Assert.IsTrue(match.MemberNames.Contains("PhoneNumber"));
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
            var model = new EnquiryDTO() { Name = "123" };
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
            var model = new EnquiryDTO() { Name = "!@#" };
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
            var model = new EnquiryDTO() { Name = "Jasmeen Kaur" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ValidValues()
        {
            // Arrange
            var model = new EnquiryDTO() { PhoneNumber = "0488999363", Email = "asd@gmail.com", Name = "Jasmeen Kaur" };
            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.IsTrue(valid);
        }

        #endregion
    }
}
