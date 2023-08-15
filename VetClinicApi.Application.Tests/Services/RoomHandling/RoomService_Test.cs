using Moq;

using System.Linq.Expressions;

using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Services.RoomHandling;
using VetClinicApi.Core.Entities;
using VetClinicApi.Core.Enums;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.Application.Tests.Services.RoomHandling
{
    public class RoomService_Test
    {
        private readonly Mock<IRoomRepository> _roomRepository = new();
        private readonly Mock<IVisitRepository> _visitRepository = new();

        private List<Visit> _visits = new List<Visit>()
            {
                new Visit(){ Id = 1, RoomId = 3},
                new Visit(){ Id = 2, RoomId = 4},
                new Visit(){ Id = 3, RoomId = 5},
                new Visit(){ Id = 4, RoomId = 7},
                new Visit(){ Id = 5, RoomId = 8}
            };
        private List<Room> _rooms = new List<Room>()
            {
                new Room { Id = 1, RoomType = RoomType.Unavailable },
                new Room { Id = 2, RoomType = RoomType.Unavailable },
                new Room { Id = 3, RoomType = RoomType.Normal },
                new Room { Id = 4, RoomType = RoomType.Normal },
                new Room { Id = 5, RoomType = RoomType.Normal },
                new Room { Id = 6, RoomType = RoomType.Normal },
                new Room { Id = 7, RoomType = RoomType.SurgicalRoom },
                new Room { Id = 8, RoomType = RoomType.SurgicalRoom },
                new Room { Id = 9, RoomType = RoomType.SurgicalRoom },
            };

        [Fact]
        public async Task Create_RoomIsNull_Test()
        {
            var roomService = new RoomService(_roomRepository.Object, _visitRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await roomService.CreateRoom(null));
        }

        [Fact]
        public async Task Delete_RoomNotFound_Test()
        {
            _roomRepository.Setup(x => x.Delete(It.IsAny<int>())).ThrowsAsync(new ArgumentOutOfRangeException());
            var roomService = new RoomService(_roomRepository.Object, _visitRepository.Object);

            await Assert.ThrowsAsync<EntityNotFoundException>(async () => await roomService.DeleteRoom(1));
        }

        [Fact]
        public async Task Update_RoomIsNull_Test()
        {
            var roomService = new RoomService(_roomRepository.Object, _visitRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await roomService.UpdateRoom(null));
        }

        [Fact]
        public async Task Update_RepositoryUpdateThrowsArgumentOutOfRangeException_ProvidedServiceNotFoundExceptionResult_Test()
        {
            var room = new Room() { Id = 1 };

            _roomRepository.Setup(x => x.Update(It.IsAny<Room>())).ThrowsAsync(new ArgumentOutOfRangeException());
            var roomService = new RoomService(_roomRepository.Object, _visitRepository.Object);

            var exception = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await roomService.UpdateRoom(room));

            Assert.Equal("Room with id = 1 not found.", exception.Message);
        }

        [Fact]
        public async Task Get_GetAvailableRoomsWithoutRoomType()
        {
            _visitRepository.Setup(x => x.GetAllByFilter(It.IsAny<DateTime>())).ReturnsAsync(_visits);
            _roomRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Room, bool>>>())).ReturnsAsync(_rooms.Where(x => x.RoomType != RoomType.Unavailable));

            var roomService = new RoomService(_roomRepository.Object, _visitRepository.Object);

            var result = await roomService.GetAvailableRooms(new DateTime());

            Assert.Equal(2, result.Count());

            foreach (var item in _rooms)
            {
                var room = result.FirstOrDefault(x => x.Id == item.Id);

                if (item.Id == 6 || item.Id == 9)
                    Assert.NotNull(room);
                else
                    Assert.Null(room);
            }
        }

        [Fact]
        public async Task Get_GetAvailableRoomsWithRoomType()
        {
            _visitRepository.Setup(x => x.GetAllByFilter(It.IsAny<DateTime>())).ReturnsAsync(_visits);
            _roomRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Room, bool>>>())).ReturnsAsync(_rooms.Where(x => x.RoomType == RoomType.Normal));

            var roomService = new RoomService(_roomRepository.Object, _visitRepository.Object);

            var result = await roomService.GetAvailableRooms(new DateTime());

            Assert.Single(result);

            foreach (var item in _rooms)
            {
                var room = result.FirstOrDefault(x => x.Id == item.Id);

                if (item.Id == 6)
                    Assert.NotNull(room);
                else
                    Assert.Null(room);
            }
        }
    }
}
