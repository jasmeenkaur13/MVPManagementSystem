using BusinessLayer;
using DataTransferObjects;
using Shared.Logger;
using System.Net.Http;
using System.Web.Http;
using WebServices.Constants;

/// <summary>
/// 
/// </summary>
namespace WebServices.Controllers
{
    /// <summary>
    /// Enquiry Controller
    /// </summary>
    public class EnquiryController : ApiController
    {
        /// <summary>
        /// Enquiry Service property
        /// </summary>
        private readonly IEnquiryService _enquiryService;
        private readonly GlobalLogger _logger;

        /// <summary>
        /// Public constructor to initialize enquiry service instance
        /// </summary>
        public EnquiryController(IEnquiryService enquiryService, GlobalLogger logger)
        {
            this._enquiryService = enquiryService;
            this._logger = logger;
        }

        /// <summary>
        /// Inserts the new Enquiry
        /// </summary>
        /// <param name="enquiryDTO"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]EnquiryDTO enquiryDTO)
        {
            this._logger.log.Info("Insertion Starts");
            if (!ModelState.IsValid)
            {
                this._logger.log.Info("Insertion ends");
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                this._logger.log.Info("Insertion ends");
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, this._enquiryService.CreateEnquiry(enquiryDTO).ToString() + WebConstants.InsertionMessage);
            }
        }
    }
}
