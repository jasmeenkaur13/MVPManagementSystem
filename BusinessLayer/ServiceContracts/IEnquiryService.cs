using DataTransferObjects;
/// <summary>
/// namespace Business Layer
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// Enquiry Service Interface
    /// </summary>
    public interface IEnquiryService
    {
        int CreateEnquiry(EnquiryDTO enquiryDTO);
    }
}
