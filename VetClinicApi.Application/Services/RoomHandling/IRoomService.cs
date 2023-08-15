using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Enums;

namespace VetClinicApi.Application.Services.RoomHandling
{
    internal interface IRoomService
    {
        Task<Room> CreateRoom(Room room);
        Task<Room> UpdateRoom(Room room);

        Task DeleteRoom(int roomId);
        Task<IEnumerable<Room>> GetAvailableRooms(DateTime visitDateTime, RoomType roomType);
        Task<IEnumerable<Room>> GetAvailableRooms(DateTime visitDateTime);
    }
}
