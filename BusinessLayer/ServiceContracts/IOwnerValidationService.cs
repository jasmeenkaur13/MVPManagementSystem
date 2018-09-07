using DataTransferObjects;

namespace BusinessLayer
{
    /// <summary>
    /// Owner Validation Service Interface
    /// </summary>
    public interface IOwnerValidationService
    {
        bool ValidateOwnerType(OwnerDTO ownerDTO);
    }
}
