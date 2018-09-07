using DataTransferObjects;

namespace BusinessLayer
{
    /// <summary>
    /// Car Owner Reference Interface
    /// </summary>
    public interface ICarOwnerReferenceService
    {
        int CreateCarOwnerReference(CarOwnerRefernceDTO carReferenceDTO);
        bool DeleteCarOwnerReference(int carRefernceId);
        CarOwnerRefernceDTO GetByCarID(int carId);
    }
}
