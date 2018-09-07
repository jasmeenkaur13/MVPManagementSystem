/// <summary>
/// namespace to hold the detals of Data transfer Obejects
/// </summary>
namespace DataTransferObjects
{
    /// <summary>
    /// DTo to hold data for advertised cars
    /// </summary>
    public class AdvertisedCarDetailsDTO
    {
        /// <summary>
        /// Details of the car
        /// </summary>
        public AdvertisedCarDTO CarDetails { get; set; }
        /// <summary>
        /// Details of the Owner
        /// </summary>
        public OwnerDTO OwnerDetails { get; set; }
    }
}
