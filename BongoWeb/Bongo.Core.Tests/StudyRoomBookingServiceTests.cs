

using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Moq;
using NUnit.Framework;

namespace Bongo.Core;

[TestFixture]
public class StudyRoomBookingServiceTests
{
    private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepositoryMock;
    private Mock<IStudyRoomRepository> _studyRoomRepositoryMock;
    private StudyRoomBookingService _bookingService;

    [SetUp]
    public void Setup()
    {
        _studyRoomBookingRepositoryMock = new Mock<IStudyRoomBookingRepository>();
        _studyRoomRepositoryMock = new Mock<IStudyRoomRepository>();
        _bookingService = new StudyRoomBookingService(
            _studyRoomBookingRepositoryMock.Object,
            _studyRoomRepositoryMock.Object);
    }
}
