

using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Bongo.Core;

[TestFixture]
public class StudyRoomBookingServiceTests
{
    private StudyRoomBooking _request;
    private List<StudyRoom> availableStudyRoom;
    private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepositoryMock;
    private Mock<IStudyRoomRepository> _studyRoomRepositoryMock;
    private StudyRoomBookingService _bookingService;

    [SetUp]
    public void Setup()
    {
        _request = new StudyRoomBooking
        {
            FirstName = "Ben",
            LastName = "Spark",
            Email = "ben@gmail.com",
            Date = new DateTime(2025, 1, 1)
        };

        availableStudyRoom = new List<StudyRoom>
        {
            new StudyRoom
            {
                Id  = 10, RoomName= "Los Angeles", RoomNumber="F630"
            }
        };

        _studyRoomBookingRepositoryMock = new Mock<IStudyRoomBookingRepository>();
        _studyRoomRepositoryMock = new Mock<IStudyRoomRepository>();
        _studyRoomRepositoryMock.Setup(x=>x.GetAll()).Returns(availableStudyRoom);
        _bookingService = new StudyRoomBookingService(
            _studyRoomBookingRepositoryMock.Object,
            _studyRoomRepositoryMock.Object);
    }


    [TestCase]
    public void GetAllBooking_InvokeMethod_CheckIfRepoIsCalled()
    {
        _bookingService.GetAllBooking();
        _studyRoomBookingRepositoryMock.Verify(x=>x.GetAll(null), Times.Once());
    }

    [TestCase]
    public void BookingException_NullRequest_ThrowsException()
    {
        var exception = Assert.Throws<ArgumentNullException>(
            ()=>_bookingService.BookStudyRoom(null));
        ClassicAssert.AreEqual("Value cannot be null. (Parameter 'request')", exception.Message);
        ClassicAssert.AreEqual("request", exception.ParamName);
    }

    [Test]
    public void StudyRoomBooking_SaveBookingWithAvailableRoom_ReturnsResultWithAllValues()
    {
        StudyRoomBooking savedStudyRoomBooking=null;
        _studyRoomBookingRepositoryMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
            .Callback<StudyRoomBooking>(booking =>
            {
                savedStudyRoomBooking = booking;
            });

        //act
        _bookingService.BookStudyRoom(_request);

        //assert

        _studyRoomBookingRepositoryMock.Verify(x=>x.Book(It.IsAny<StudyRoomBooking>()), Times.Once());

        ClassicAssert.NotNull(savedStudyRoomBooking);
        ClassicAssert.AreEqual(_request.FirstName, savedStudyRoomBooking.FirstName);
        ClassicAssert.AreEqual(_request.LastName, savedStudyRoomBooking.LastName);
        ClassicAssert.AreEqual(_request.Email, savedStudyRoomBooking.Email);
        ClassicAssert.AreEqual(_request.Date, savedStudyRoomBooking.Date);
        ClassicAssert.AreEqual(availableStudyRoom.First().Id, savedStudyRoomBooking.StudyRoomId);
    }

    [Test]
    public void StudyRoomBookingResultCheck_InputRequest_ValuesMatchInResult()
    {
        StudyRoomBookingResult result = _bookingService.BookStudyRoom(_request);

        ClassicAssert.NotNull(result);

        ClassicAssert.AreEqual(_request.FirstName, result.FirstName);
        ClassicAssert.AreEqual(_request.LastName, result.LastName);
        ClassicAssert.AreEqual(_request.Email, result.Email);
        ClassicAssert.AreEqual(_request.Date, result.Date);
    }

    [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
    [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
    public StudyRoomBookingCode ResultCodeSuccess_RoomAvability_Returns(bool roomAvailablity)
    {
        if (!roomAvailablity)
        {
            availableStudyRoom.Clear();
        }

        return _bookingService.BookStudyRoom(_request).Code;

    }
}
