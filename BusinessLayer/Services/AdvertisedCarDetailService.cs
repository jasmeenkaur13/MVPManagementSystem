using DataTransferObjects;
using System.Collections.Generic;

/// <summary>
/// Business Layer namespace
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// Car details Servces
    /// </summary>
    public class AdvertisedCarDetailService : IAdvertiseCarDetailsService
    {
        private readonly IOwnerService _ownerService;
        private readonly IAdvertiseCarService _advertiseCarService;
        private readonly ICarOwnerReferenceService _carOwnerReferenceService;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public AdvertisedCarDetailService(IOwnerService ownerService, IAdvertiseCarService advertiseCarService, ICarOwnerReferenceService carOwnerReferenceService)
        {
            this._ownerService = ownerService;
            this._advertiseCarService = advertiseCarService;
            this._carOwnerReferenceService = carOwnerReferenceService;
        }

        /// <summary>
        /// Creates a car entry
        /// </summary>
        /// <param name="advertiseCarDTO"></param>
        /// <returns></returns>
        public int CreateAdvertiseCarDetailsEntry(AdvertisedCarDetailsDTO advertiseCarDTO)
        {
            int ownerId = this._ownerService.CreateOwner(advertiseCarDTO.OwnerDetails);
            int carId = this._advertiseCarService.CreateAdvertiseCar(advertiseCarDTO.CarDetails);
            CarOwnerRefernceDTO refernce = new CarOwnerRefernceDTO
            {
                CarId = carId,
                OwnerId = ownerId
            };
            this._carOwnerReferenceService.CreateCarOwnerReference(refernce);
            return carId;
        }

        /// <summary>
        /// Updates a car
        /// </summary>
        /// <param name="advertiseCarId"></param>
        /// <param name="advertiseCarDTO"></param>
        /// <returns></returns>
        public bool UpdateAdvertiseCarDetailsEntry(int advertiseCarId, AdvertisedCarDetailsDTO advertiseCarDTO)
        {
            var success = false;
            if (advertiseCarDTO != null && advertiseCarId >0)
            {
                var carReference = this._carOwnerReferenceService.GetByCarID(advertiseCarId);
                if (advertiseCarDTO.CarDetails != null && carReference != null)
                {
                    this._advertiseCarService.UpdateAdvertiseCar(advertiseCarId, advertiseCarDTO.CarDetails);
                    success = true;
                }
                if (advertiseCarDTO.OwnerDetails != null && carReference != null)
                {
                    this._ownerService.UpdateOwner(carReference.OwnerId, advertiseCarDTO.OwnerDetails);
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular car
        /// </summary>
        /// <param name="advertiseCarId"></param>
        /// <returns></returns>
        public bool DeleteAdvertiseCarDetailsEntry(int advertiseCarId)
        {
            var success = false;
            if (advertiseCarId >= 0)
            {
                var carReference = this._carOwnerReferenceService.GetByCarID(advertiseCarId);
                if (carReference != null)
                {
                    this._advertiseCarService.DeleteAdvertiseCar(advertiseCarId);
                    this._ownerService.DeleteOwner(carReference.OwnerId);
                    this._carOwnerReferenceService.DeleteCarOwnerReference(carReference.Id);
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Search the list of advertised cars and get details
        /// </summary>
        /// <param name="make"></param>
        /// <param name="year"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList<AdvertisedCarDTO> GetListOfAdvertisedCars(string make, string year, string model)
        {
            return this._advertiseCarService.GetListOfAdvertisedCars(make, year, model);
        }
    }
}