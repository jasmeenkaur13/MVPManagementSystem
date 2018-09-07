using BusinessLayer;
using DataTransferObjects;
using Shared.Logger;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WebServices.Constants;

/// <summary>
/// 
/// </summary>
namespace WebServices.Controllers
{
    /// <summary>
    /// Car Details controller
    /// </summary>
    public class AdvertisedCarController : ApiController
    {
        private readonly IAdvertiseCarDetailsService _advertiseCarDetailsService;
        private readonly IOwnerValidationService _ownerValidationService;
        private readonly GlobalLogger _logger;

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AdvertisedCarController(IAdvertiseCarDetailsService advertiseCarDetailsService, IOwnerValidationService ownerValidationService, GlobalLogger logger)
        {
            _advertiseCarDetailsService = advertiseCarDetailsService;
            _ownerValidationService = ownerValidationService;
            _logger = logger;

        }

        /// <summary>
        /// fetched the list of cars advertised
        /// </summary>
        /// <returns></returns>
        public IList<AdvertisedCarDTO> Get(string make, string year, string model)
        {
            _logger.log.Info("Fetching the List");
            var cars = _advertiseCarDetailsService.GetListOfAdvertisedCars(make, year, model);
            _logger.log.Info("Fetched the List with count = " + cars.Count.ToString());
            return cars;

        }

        /// <summary>
        /// Insert the car details
        /// </summary>
        /// <param name="carDetailsDTO"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]AdvertisedCarDetailsDTO carDetailsDTO)
        {
            _logger.log.Info("Inserting starts");
            if (!ModelState.IsValid)
            {
                _logger.log.Info("Inserting ends");
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                if (_ownerValidationService.ValidateOwnerType(carDetailsDTO.OwnerDetails))
                {
                    _logger.log.Info("Inserting ends");
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, _advertiseCarDetailsService.CreateAdvertiseCarDetailsEntry(carDetailsDTO).ToString() + WebConstants.InsertionMessage);
                }
                else
                {
                    _logger.log.Info("Inserting ends");
                    return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, WebConstants.OwnerTypeValidationMessage);
                }
            }

        }

        /// <summary>
        /// Update the car details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carDetailsDTO"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, [FromBody]AdvertisedCarDetailsDTO carDetailsDTO)
        {
            _logger.log.Info("Updating starts for " + id.ToString());
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                if (id > 0)
                {
                    if (_ownerValidationService.ValidateOwnerType(carDetailsDTO.OwnerDetails))
                    {
                        if (_advertiseCarDetailsService.UpdateAdvertiseCarDetailsEntry(id, carDetailsDTO))
                        {
                            _logger.log.Info("Updating ends for " + id.ToString());
                            return Request.CreateResponse(System.Net.HttpStatusCode.OK, WebConstants.UpdationMessage);
                        }
                        else
                        {
                            _logger.log.Info("Updating ends for " + id.ToString());
                            return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, WebConstants.IDDoesNotExist);
                        }
                    }
                    else
                    {
                        _logger.log.Info("Updating ends for " + id.ToString());
                        return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, WebConstants.OwnerTypeValidationMessage);
                    }
                }
                _logger.log.Info("Updating ends for " + id.ToString());
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, WebConstants.IDDoesNotExist);
            }
        }

        /// <summary>
        /// Delete the Car details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            _logger.log.Info("Deleting starts for " + id.ToString());
            if (id > 0)
            {
                if (_advertiseCarDetailsService.DeleteAdvertiseCarDetailsEntry(id))
                {
                    _logger.log.Info("Deleting ends for " + id.ToString());
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, WebConstants.DeletionMessage);
                }
            }
            _logger.log.Info("Deleting ends for " + id.ToString());
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, WebConstants.IDDoesNotExist);
        }
    }
}
