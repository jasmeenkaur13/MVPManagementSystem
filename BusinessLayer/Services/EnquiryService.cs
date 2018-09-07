using DataModels;
using DataModels.UnitOfWork;
using DataTransferObjects;

/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// Class to implement Enquiry Service 
    /// </summary>
    public class EnquiryService: IEnquiryService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public EnquiryService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates an enquiry
        /// </summary>
        /// <param name="enquiryDTO"></param>
        /// <returns></returns>
        public int CreateEnquiry(EnquiryDTO enquiryDTO)
        {
           var enquiry = new Enquiry
                {
                    CarId = enquiryDTO.CarId,
                    Name = enquiryDTO.Name,
                    Email = enquiryDTO.Email,
                    PhoneNumber = enquiryDTO.PhoneNumber
                };
            this._unitOfWork.EnquiryRepository.Insert(enquiry);
            this._unitOfWork.Save();
            return enquiry.EnquiryId;
           
        }
    }
}