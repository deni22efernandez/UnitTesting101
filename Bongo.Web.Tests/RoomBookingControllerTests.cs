using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

namespace Bongo.Web.Tests
{
	[TestFixture]
	public class RoomBookingControllerTests
	{
		private Mock<IStudyRoomBookingService> _studyRoomBookingService;
		private RoomBookingController controller;
		[SetUp]
		public void Setup()
		{
			_studyRoomBookingService = new Mock<IStudyRoomBookingService>();
			controller = new RoomBookingController(_studyRoomBookingService.Object);
		}
		[Test]
		public void Index_VerfifyStudyRoomBookingService_GetAllBooking_GetsCalled()
		{
			controller.Index();
			_studyRoomBookingService.Verify(x => x.GetAllBooking(), Times.Once);
		}
		[TestCase()]
		public void BookPost_InvalidModelState_ReturnsBookView()
		{
			controller.ModelState.AddModelError("test", "test");
			ViewResult result = (ViewResult)controller.Book(new StudyRoomBooking());
			Assert.AreEqual("Book", result.ViewName);
			
		}
		[TestCase()]
		public void BookPost_ValidModelState_ReturnsRedrectToAction()
		{
			
			_studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
				.Returns(new StudyRoomBookingResult() { Code = StudyRoomBookingCode.Success });

			RedirectToActionResult result = (RedirectToActionResult)controller.Book(new StudyRoomBooking());

			Assert.AreEqual("BookingConfirmation", result.ActionName);

		}
		[TestCase()]
		public void BookPost_ValidModelState_ReturnsRedirectToActionType()
		{

			_studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
				.Returns(new StudyRoomBookingResult() { Code = StudyRoomBookingCode.Success });

			var result = controller.Book(new StudyRoomBooking());

			//Assert.That(result, Is.TypeOf<RedirectToActionResult>());
			Assert.IsInstanceOf<RedirectToActionResult>(result);

		}
		[TestCase()]
		public void BookPost_InValidModelState_CheckErrorMessage()
		{

			_studyRoomBookingService.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
				.Returns(new StudyRoomBookingResult() { Code = StudyRoomBookingCode.NoRoomAvailable });
			string errorMesg= "No Study Room available for selected date";

			ViewResult result = (ViewResult)controller.Book(new StudyRoomBooking());

			Assert.That(result.ViewData["Error"], Is.EqualTo(errorMesg));

		}
	}
}
