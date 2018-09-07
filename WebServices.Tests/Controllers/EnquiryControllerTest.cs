
using BusinessLayer;
using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebServices.Controllers;

namespace WebServices.Tests.Controllers
{
    /// <summary>
    /// Test class to test methods of AdvertisedCarController
    /// </summary>
    [TestClass]
    public class EnquiryControllerTest
    {
        #region Private Readonly vaiables
        private readonly GlobalLogger _logger = new GlobalLogger();
        #endregion

        #region Action Test Case
        /// <summary>
        /// Post the Enquiry car details Object Successful
        /// </summary>
        [TestMethod]
        public void Post()
        {
            int a = 1;
            // bool yes = true;

            var mockRepositorycar = new Mock<IEnquiryService>();
            var ab = new EnquiryDTO
            {
                CarId = 1,
                EnquiryId = 1,
                Email = "sample string 3",
                Name = "sample string 4",
                PhoneNumber = "eCg",
            };
            mockRepositorycar.Setup(x => x.CreateEnquiry(ab)).Returns(a);


            // Arrange
            EnquiryController controller = new EnquiryController(mockRepositorycar.Object, _logger);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(ab);
            string succesful;
            Assert.IsTrue(response.TryGetContentValue<string>(out succesful));
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(succesful, "1 Inserted successfully");
        }

        #endregion


    }
}
