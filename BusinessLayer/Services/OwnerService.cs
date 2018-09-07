using DataModels;
using DataModels.UnitOfWork;
using DataTransferObjects;

/// <summary>
/// 
/// </summary>
namespace BusinessLayer
{
    /// <summary>
    /// Class to Implement Owner Service
    /// </summary>
    public class OwnerService: IOwnerService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public OwnerService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        


        /// <summary>
        /// Creates a owner
        /// </summary>
        /// <param name="ownerDTO"></param>
        /// <returns></returns>
        public int CreateOwner(OwnerDTO ownerDTO)
        {
           var owner = new Owner
                {
                    Comments = ownerDTO.Comments,
                    Name = ownerDTO.Name,
                    Email = ownerDTO.Email,
                    PhoneNumber = ownerDTO.PhoneNumber,
                    DealerABN = ownerDTO.DealerABN,
                    OwnerType = ownerDTO.OwnerType
                };
            this._unitOfWork.OwnerRepository.Insert(owner);
            this._unitOfWork.Save();
            return owner.Id;
           
        }

        /// <summary>
        /// Updates a owner
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="OwnerDTO"></param>
        /// <returns></returns>
        public bool UpdateOwner(int ownerId, OwnerDTO ownerDTO)
        {
            var success = false;
            if (ownerDTO != null)
            {
            
                var owner = this._unitOfWork.OwnerRepository.GetByID(ownerId);
                if (owner != null)
                {
                    owner.Comments = ownerDTO.Comments;
                    owner.Name = ownerDTO.Name;
                    owner.Email = ownerDTO.Email;
                    owner.PhoneNumber = ownerDTO.PhoneNumber;
                    owner.DealerABN = ownerDTO.DealerABN;
                    owner.OwnerType = ownerDTO.OwnerType;
                    this._unitOfWork.OwnerRepository.Update(owner);
                    this._unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular owner
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public bool DeleteOwner(int ownerId)
        {
            var success = false;
            if (ownerId > 0)
            {
               var owner = this._unitOfWork.OwnerRepository.GetByID(ownerId);
                if (owner != null)
                {
                    this._unitOfWork.OwnerRepository.Delete(owner);
                    this._unitOfWork.Save();
                    success = true;
                }
            }
            return success;
        }
    }
}