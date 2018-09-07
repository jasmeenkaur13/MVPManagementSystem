using DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Tests
{
    /// <summary>
    /// Test class for AdvertisedCarDetailService
    /// </summary>
    [TestClass]
    public class AdvertisedCarDetailServiceTest
    {
        /// <summary>
        /// Create new Advertise car details
        /// </summary>
        [TestMethod]
        public void CreateAdvertiseCarDetailsEntrySuccess()
        {
            var carDetailsObject = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "2017",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    DealerABN = "fgds",
                    OwnerType = "D",
                    Comments = "sample string 7",
                }
            };

            var carReference = new CarOwnerRefernceDTO
            {
                CarId = 2,
                OwnerId = 1
            };
            var mockRepository = new Mock<IOwnerService>();
            mockRepository.Setup(x => x.CreateOwner(carDetailsObject.OwnerDetails))
                .Returns(1);

            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            mockRepositoryCar.Setup(x => x.CreateAdvertiseCar(carDetailsObject.CarDetails))
                .Returns(2);

            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            mockRepositoryCarRef.Setup(x => x.CreateCarOwnerReference(carReference))
                .Returns(1);

            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.CreateAdvertiseCarDetailsEntry(carDetailsObject);
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results);
        }

        /// <summary>
        /// Update Advertise car details
        /// </summary>
        [TestMethod]
        public void UpdateAdvertiseCarDetailsEntrySuccess()
        {
            int carId = 1;
            var carDetailsObject = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "2017",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    DealerABN = "fgds",
                    OwnerType = "D",
                    Comments = "sample string 7",
                }
            };

            var carReference = new CarOwnerRefernceDTO
            {
                CarId = 1,
                OwnerId = 1
            };
            var mockRepository = new Mock<IOwnerService>();
            mockRepository.Setup(x => x.UpdateOwner(carReference.OwnerId, carDetailsObject.OwnerDetails))
                .Returns(true);

            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            mockRepositoryCar.Setup(x => x.UpdateAdvertiseCar(carId, carDetailsObject.CarDetails))
                .Returns(true);

            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            mockRepositoryCarRef.Setup(x => x.GetByCarID(carId))
                .Returns(carReference);

            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.UpdateAdvertiseCarDetailsEntry(carId, carDetailsObject);
            Assert.IsNotNull(results);
            Assert.IsTrue(results);
        }

        /// <summary>
        /// Update Advertise car details null object update fails
        /// </summary>
        [TestMethod]
        public void UpdateAdvertiseCarDetailsEntrySuccessInvalid()
        {
            int carId = 1;
            var mockRepository = new Mock<IOwnerService>();
            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.UpdateAdvertiseCarDetailsEntry(carId, null);
            Assert.IsNotNull(results);
            Assert.IsFalse(results);
        }

        /// <summary>
        /// Update Advertise car details null object update fails
        /// </summary>
        [TestMethod]
        public void UpdateAdvertiseCarDetailsEntrySuccessInvalidId()
        {
            int carId = 0;
            var mockRepository = new Mock<IOwnerService>();
            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.UpdateAdvertiseCarDetailsEntry(carId, null);
            Assert.IsNotNull(results);
            Assert.IsFalse(results);
        }

        /// <summary>
        /// Update Advertise car details car Reference update fails
        /// </summary>
        [TestMethod]
        public void UpdateAdvertiseCarDetailsEntrySuccessCarReferenceInvalid()
        {
            int carId = 1;
            var carDetailsObject = new AdvertisedCarDetailsDTO
            {
                CarDetails = new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "2017",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                },
                OwnerDetails = new OwnerDTO
                {
                    Id = 1,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    DealerABN = "fgds",
                    OwnerType = "D",
                    Comments = "sample string 7",
                }
            };
            CarOwnerRefernceDTO carReference = null;
            var mockRepository = new Mock<IOwnerService>();
            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            mockRepositoryCarRef.Setup(x => x.GetByCarID(carId)).Returns(carReference);
            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.UpdateAdvertiseCarDetailsEntry(carId, carDetailsObject);
            Assert.IsNotNull(results);
            Assert.IsFalse(results);
        }

        /// <summary>
        /// Delete Advertise car details
        /// </summary>
        [TestMethod]
        public void DeleteAdvertiseCarDetailsEntrySuccess()
        {
            var carId = 1;
            var carReference = new CarOwnerRefernceDTO
            {
                CarId = 2,
                OwnerId = 1
            };
            var mockRepository = new Mock<IOwnerService>();
            mockRepository.Setup(x => x.DeleteOwner(carReference.OwnerId))
                .Returns(true);

            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            mockRepositoryCar.Setup(x => x.DeleteAdvertiseCar(carId))
                .Returns(true);

            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            mockRepositoryCarRef.Setup(x => x.GetByCarID(carId))
                .Returns(carReference);

            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.DeleteAdvertiseCarDetailsEntry(carId);
            Assert.IsNotNull(results);
            Assert.IsTrue(results);
        }

        /// <summary>
        /// Delete Advertise car details null carReference
        /// </summary>
        [TestMethod]
        public void DeleteAdvertiseCarDetailsEntrySuccessInvalid()
        {
            var carId = 1;
            CarOwnerRefernceDTO carReference = null;
            var mockRepository = new Mock<IOwnerService>();
            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            mockRepositoryCarRef.Setup(x => x.GetByCarID(carId))
                .Returns(carReference);
            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.DeleteAdvertiseCarDetailsEntry(carId);
            Assert.IsNotNull(results);
            Assert.IsFalse(results);
        }

        /// <summary>
        /// Delete Advertise car details invalid ID
        /// </summary>
        [TestMethod]
        public void DeleteAdvertiseCarDetailsEntrySuccessInvalidId()
        {
            var carId = 0;
            CarOwnerRefernceDTO carReference = null;
            var mockRepository = new Mock<IOwnerService>();
            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();
            mockRepositoryCarRef.Setup(x => x.GetByCarID(carId))
                .Returns(carReference);
            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.DeleteAdvertiseCarDetailsEntry(carId);
            Assert.IsNotNull(results);
            Assert.IsFalse(results);
        }

        /// <summary>
        /// Get List of Cars
        /// </summary>
        [TestMethod]
        public void GetListOfAdvertisedCarsSuccess()
        {
            var carDetailsObject = new List<AdvertisedCarDTO>
            { new AdvertisedCarDTO
                {
                    ID = 1,
                    Year = "2017",
                    Make = "sample string 3",
                    Model = "sample string 4",
                    AdvertisedPriceType = "eCg",
                    ECGAmount = 6.0m,
                    DAPAmount = 7.0m,
                    AdvertisedAmount = 8.0m,
                } };
            var mockRepository = new Mock<IOwnerService>();
            var mockRepositoryCar = new Mock<IAdvertiseCarService>();
            mockRepositoryCar.Setup(x => x.GetListOfAdvertisedCars("2017", "abc", "abc"))
               .Returns(carDetailsObject);
            var mockRepositoryCarRef = new Mock<ICarOwnerReferenceService>();

            AdvertisedCarDetailService services = new AdvertisedCarDetailService(mockRepository.Object, mockRepositoryCar.Object, mockRepositoryCarRef.Object);
            var results = services.GetListOfAdvertisedCars("2017", "abc", "abc");
            Assert.AreEqual(results.Count, 1);
            Assert.AreEqual(results.FirstOrDefault().ID, 1);
        }
    }
}
