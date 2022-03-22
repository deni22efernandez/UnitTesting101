using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bongo.DataAccess.Tests
{
	[TestFixture]
	public class StudyRoomBookingRepositoryNUnitTests
	{
		private DbContextOptions<ApplicationDbContext> options;
		private StudyRoomBooking studyRoom1;
		private StudyRoomBooking studyRoom2;
		[SetUp]
		public void Setup()
		{
			options = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "InMemoDb").Options;
		}		

		public StudyRoomBookingRepositoryNUnitTests()
		{
			studyRoom1 = new StudyRoomBooking
			{
				BookingId = 1,
				Date = DateTime.Now.AddDays(1),
				Email = "test1@gmail.com",
				FirstName = "test1",
				LastName = "test1",
				StudyRoomId = 1
			};
			studyRoom2 = new StudyRoomBooking
			{
				BookingId = 2,
				Date = DateTime.Now.AddDays(2),
				Email = "test2@gmail.com",
				FirstName = "test2",
				LastName = "test2",
				StudyRoomId = 2
			};
			
		}
		[Test]
		public void Book_InputStudyRoom1_ReturnsSameObject()
		{
			//ARRANGE
		

			//ACT
			using (var dbContext = new ApplicationDbContext(options))
			{
				var repo = new StudyRoomBookingRepository(dbContext);
				repo.Book(studyRoom1);

			}
			//ASSERT
			using (var dbContext = new ApplicationDbContext(options))
			{
				var result = dbContext.StudyRoomBookings.FirstOrDefault(x => x.BookingId == 1);
				Assert.AreEqual(studyRoom1.BookingId, result.BookingId);
				Assert.AreEqual(studyRoom1.Date, result.Date);
				Assert.AreEqual(studyRoom1.Email, result.Email);
				Assert.AreEqual(studyRoom1.FirstName, result.FirstName);
				Assert.AreEqual(studyRoom1.LastName, result.LastName);
				Assert.AreEqual(studyRoom1.StudyRoomId, result.StudyRoomId);
			}

		}
		[Test]
		public void GetAll_InputStudyRoom1And2_ReturnsSameInMemoryDbObjects()
		{
			//Arrange
			var expectedResult = new List<StudyRoomBooking> { studyRoom1, studyRoom2 };
			
			
			using(var dbContxt = new ApplicationDbContext(options))
			{
				dbContxt.Database.EnsureDeleted();
				var repo = new StudyRoomBookingRepository(dbContxt);
				repo.Book(studyRoom1);
				repo.Book(studyRoom2);
			}
			//Act
			List<StudyRoomBooking> inMemoryList = new List<StudyRoomBooking>(); 
			using (var dbContxt = new ApplicationDbContext(options))
			{
				var repo = new StudyRoomBookingRepository(dbContxt);
				inMemoryList = repo.GetAll(null).ToList();
				
			}
			//Assert
			CollectionAssert.AreEqual(expectedResult, inMemoryList, new BookingComparer());
		}
		private class BookingComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				var firstBooking=(StudyRoomBooking)x;
				var secondBooking = (StudyRoomBooking)y;
				if (firstBooking.BookingId == secondBooking.BookingId)
				{
					return 0;
				}
				return 1;
			}
		}

	}
	
}
