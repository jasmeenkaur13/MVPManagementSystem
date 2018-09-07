using DataTransferObjects;
/// <summary>
/// namespace Business Layer
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// Owner Service Interface
    /// </summary>
    public interface IOwnerService
    {
        int CreateOwner(OwnerDTO ownerDTO);
        bool UpdateOwner(int ownerId, OwnerDTO ownerDTO);
        bool DeleteOwner(int ownerId);
    }
}
