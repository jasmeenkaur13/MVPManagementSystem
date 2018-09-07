/// <summary>
/// namespace to hold the detals of Data transfer Obejects
/// </summary>
namespace DataTransferObjects
{
    /// <summary>
    /// DTo to hold data for advertised cars
    /// </summary>
    public class CarOwnerRefernceDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Linked Owner Id
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// Linked Car Id
        /// </summary>
        public int CarId { get; set; }

    }
}
