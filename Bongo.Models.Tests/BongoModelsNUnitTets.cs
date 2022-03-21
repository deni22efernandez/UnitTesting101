using Bongo.Models.ModelValidations;
using NUnit.Framework;
using System;

namespace Bongo.Models.Tests
{
	[TestFixture]
	public class BongoModelsNUnitTets
	{
		[SetUp]
		public void Setup()
		{

		}
		[Test]
		public void DateInFutureAttribute_Constructor_DefaultErrorMessage()
		{
			//ARRANGE
			var expected = "Date must be in the future";
			//ACT
			var result = new DateInFutureAttribute();
			//ASSERT
			Assert.AreEqual(expected, result.ErrorMessage);
		}

		[Test]
		public void IsValid_InputFutureDate_ReturnsTrue()
		{
			//ARRANGE
			DateInFutureAttribute dateAttr = new DateInFutureAttribute();
			
			//ACT
			bool result=dateAttr.IsValid(DateTime.Now.AddSeconds(100));
			//ASSERT
			Assert.IsTrue(result);
		}
		[Test]
		[TestCase(50, ExpectedResult =true)]
		[TestCase(0, ExpectedResult = false)]
		[TestCase(-50, ExpectedResult = false)]
		public bool IsValid_InputTestsCases_ReturnsValidity(int value)
		{
			//ARRANGE
			DateInFutureAttribute dateAttr = new DateInFutureAttribute();

			//ACT
			return dateAttr.IsValid(DateTime.Now.AddSeconds(value));
			
		}
	}
}
