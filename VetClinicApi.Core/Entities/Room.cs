using VetClinicApi.Core.Enums;

namespace VetClinicApi.Core.Entities
{
    public class Room : IEntity
    {
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
    }
}
