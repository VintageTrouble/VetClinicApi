namespace VetClinicApi.Core.Entities.Interfaces
{
    public interface ITrackableEntity : IEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}
