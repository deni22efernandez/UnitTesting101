using Bongo.Core.Services;
using Bongo.DataAccess.Repository;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bongo.Core.Tests
{
	[TestFixture]
	public class StudyRoomBookingServiceTests
	{
		private StudyRoomBookingService studyRoomBookingService;
		private Mock<IStudyRoomBookingRepository> bookingRepository;
		private Mock<IStudyRoomRepository> studyRoomRepository;
		private StudyRoomBooking studyRoomBooking;
		private List<StudyRoom> availableRoomsForTest;

		[SetUp]
		public void Setup()
		{
			bookingRepository = new Mock<IStudyRoomBookingRepository>();
			studyRoomRepository = new Mock<IStudyRoomRepository>();
			studyRoomBookingService = new StudyRoomBookingService(bookingRepository.Object, studyRoomRepository.Object);
			studyRoomBooking = new StudyRoomBooking
			{
				Date = DateTime.Now.AddDays(2),
				Email = "dummy@gmail.com",
				FirstName = "dummyName",
				LastName = "dummyLastName"
			};
			availableRoomsForTest = new List<StudyRoom>()
			{
				new StudyRoom()
				{
					 Id=7,
					 RoomName="test",
					 RoomNumber="2"
				}
			};
			studyRoomRepository.Setup(x => x.GetAll()).Returns(availableRoomsForTest);
		}
		[Test]
		public void GetAllBooking_VerifyIfRepoGetsCalled()
		{
			//Arrange	

			//Act
			studyRoomBookingService.GetAllBooking();
			//Assert
			bookingRepository.Verify(x => x.GetAll(null), Times.Once);

		}
		[Test]
		public void BookStudyRoom_InputNullStudyRoomBooking_ReturnsArgumentNullException()
		{
			//Arrange

			//Act+Assert
			Assert.Throws<ArgumentNullException>(() => studyRoomBookingService.BookStudyRoom(null));
		}

		[Test]
		public void BookStudyRoom_InputStudyRoomBooking_ReturnsStudyRoomBookingResult()
		{
			//Arrange
			StudyRoomBooking savedstudyRoomBooking = null;
			bookingRepository.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
							 .Callback<StudyRoomBooking>(booking => { savedstudyRoomBooking = booking; });

			//Act
			studyRoomBookingService.BookStudyRoom(studyRoomBooking);
			//Assert that the booked room Id was the only room I set on setup (id=7)
			Assert.That(availableRoomsForTest.First().Id, Is.EqualTo(savedstudyRoomBooking.StudyRoomId));
		}
	}
}
