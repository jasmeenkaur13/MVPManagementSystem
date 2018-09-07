using AutoMapper;
using DataModels;
using DataModels.UnitOfWork;
using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// class for CRUD operation of Advertise cars
    /// </summary>
    public class AdvertisedCarService : IAdvertiseCarService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public AdvertisedCarService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a car entry
        /// </summary>
        /// <param name="advertiseCarDTO"></param>
        /// <returns></returns>
        public int CreateAdvertiseCar(AdvertisedCarDTO advertiseCarDTO)
        {
            var car = new AdvertisedCar
            {
                Year = advertiseCarDTO.Year,
                Make = advertiseCarDTO.Make,
                AdvertisedAmount = advertiseCarDTO.AdvertisedAmount,
                DAPAmount = advertiseCarDTO.DAPAmount,
                ECGAmount = advertiseCarDTO.ECGAmount,
                AdvertisedPriceType = advertiseCarDTO.AdvertisedPriceType,
                Model = advertiseCarDTO.Model
            };
            this._unitOfWork.AdvertsedCarRepository.Insert(car);
            this._unitOfWork.Save();
            return car.ID;

        }

        /// <summary>
        /// Updates a car
        /// </summary>
        /// <param name="advertiseCarId"></param>
        /// <param name="advertiseCarDTO"></param>
        /// <returns></returns>
        public bool UpdateAdvertiseCar(int advertiseCarId, AdvertisedCarDTO advertiseCarDTO)
        {
            var success = false;
            if (advertiseCarDTO != null)
            {

                var car = this._unitOfWork.AdvertsedCarRepository.GetByID(advertiseCarId);
                if (car != null)
                {
                    car.Year = advertiseCarDTO.Year;
                    car.Make = advertiseCarDTO.Make;
                    car.AdvertisedAmount = advertiseCarDTO.AdvertisedAmount;
                    car.DAPAmount = advertiseCarDTO.DAPAmount;
                    car.ECGAmount = advertiseCarDTO.ECGAmount;
                    car.AdvertisedPriceType = advertiseCarDTO.AdvertisedPriceType;
                    car.Model = advertiseCarDTO.Model;
                    _unitOfWork.AdvertsedCarRepository.Update(car);
                    _unitOfWork.Save();
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
        public bool DeleteAdvertiseCar(int advertiseCarId)
        {
            var success = false;
            if (advertiseCarId > 0)
            {
                var car = this._unitOfWork.AdvertsedCarRepository.GetByID(advertiseCarId);
                if (car != null)
                {

                    this._unitOfWork.AdvertsedCarRepository.Delete(car);
                    this._unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        public IList<AdvertisedCarDTO> GetListOfAdvertisedCars(string make, string year, string model)
        {
            var carReference = this._unitOfWork.AdvertsedCarRepository.GetMany(x => string.Equals(x.Model, string.IsNullOrWhiteSpace(model) ? x.Model : model) &&
            string.Equals(x.Year, string.IsNullOrWhiteSpace(year) ? x.Year : year) &&
            string.Equals(x.Make, string.IsNullOrWhiteSpace(make) ? x.Make : make)
            ).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdvertisedCar, AdvertisedCarDTO>();
            });
            IMapper mapper = config.CreateMapper();
            var carRefernceDTO = mapper.Map<IList<AdvertisedCar>, IList<AdvertisedCarDTO>>(carReference);
            return carRefernceDTO;
        }
    }
}