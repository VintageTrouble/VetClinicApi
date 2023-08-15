using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Enums;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.Services.RoomHandling;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IVisitRepository _visitRepository;
    public RoomService(IRoomRepository roomRepository, IVisitRepository visitRepository)
    {
        _roomRepository = roomRepository;
        _visitRepository = visitRepository;
    }

    public async Task<Room> CreateRoom(Room room)
    {
        if (room is null)
            throw new ArgumentNullException(nameof(room), "Room can't be null");

        return await _roomRepository.Add(room);
    }

    public async Task DeleteRoom(int roomId)
    {
        try
        {
            await _roomRepository.Delete(roomId);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new EntityNotFoundException(roomId, "Room");
        }
    }

    public async Task<IEnumerable<Room>> GetAvailableRooms(DateTime visitDateTime, RoomType roomType)
    {
        return await GetAllAvailableRooms(visitDateTime, roomType);
    }

    public async Task<IEnumerable<Room>> GetAvailableRooms(DateTime visitDateTime)
    {
        return await GetAllAvailableRooms(visitDateTime, null);
    }

    public async Task<Room> UpdateRoom(Room room)
    {
        if (room is null)
            throw new ArgumentNullException(nameof(room), "Room can't be null");

        try
        {
            return await _roomRepository.Update(room);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new EntityNotFoundException(room.Id, "Room");
        }
    }

    private async Task<IEnumerable<Room>> GetAllAvailableRooms(DateTime visitDateTime, RoomType? roomType)
    {
        var visits = await _visitRepository.GetAllByFilter(visitDateTime);
        var rooms = visits.Select(x => x.RoomId);
        var allRooms = roomType.HasValue
            ? await _roomRepository.GetAll(x => x.RoomType == roomType)
            : await _roomRepository.GetAll(x => x.RoomType != RoomType.Unavailable);

        return allRooms.Where(x => !rooms.Contains(x.Id));
    }
}
