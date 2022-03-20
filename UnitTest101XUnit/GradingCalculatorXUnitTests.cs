
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace UnitTest101
//{
//	[TestFixture]
//	public class GradingCalculatorXUnitTests
//	{
//		private GradingCalculator grading;

//		[SetUp]
//		public void Setup()
//		{
//			grading = new GradingCalculator();
//		}
//		[Test]
//		public void GetGrade_InputScore95Attendance90_OutputsA()
//		{
//			//Arrange
//			grading.Score = 95;
//			grading.AttendancePercentage = 90;
//			//Act
//			var result = grading.GetGrade();
//			//Assert
//			Assert.That(result, Is.EqualTo("A"));
//			Assert.AreEqual("A", result);
//		}
//		[Test]
//		public void GetGrade_InputScore85Attendance90_OutputsB()
//		{
//			//Arrange
//			grading.Score = 85;
//			grading.AttendancePercentage = 90;
//			//Act
//			var result = grading.GetGrade();
//			//Assert
//			Assert.That(result, Is.EqualTo("B"));
//			Assert.AreEqual("B", result);
//		}
//		[Test]
//		public void GetGrade_InputScore65Attendance90_OutputsC()
//		{
//			//Arrange
//			grading.Score = 65;
//			grading.AttendancePercentage = 90;
//			//Act
//			var result = grading.GetGrade();
//			//Assert
//			Assert.That(result, Is.EqualTo("C"));
//			Assert.AreEqual("C", result);
//		}
//		[Test]
//		public void GetGrade_InputScore95Attendance65_OutputsB()
//		{
//			//Arrange
//			grading.Score = 95;
//			grading.AttendancePercentage = 65;
//			//Act
//			var result = grading.GetGrade();
//			//Assert
//			Assert.That(result, Is.EqualTo("B"));
//			Assert.AreEqual("B", result);
//		}
//		[Test]
//		[TestCase(95,55,ExpectedResult ="F")]
//		[TestCase(65, 55, ExpectedResult = "F")]
//		[TestCase(50, 90, ExpectedResult = "F")]
//		public string GetGrade_InputFromTestCase1_OutputsF(int a, int b)
//		{
//			//Arrange
//			grading.Score = a;
//			grading.AttendancePercentage = b;
//			//Act
//			return grading.GetGrade();
//			//Assert
//			//Assert.That(result, Is.EqualTo("B"));
//			//Assert.AreEqual("B", result);
//		}
		
//		[Test]
//		[TestCase(95, 55)]
//		[TestCase(65, 55)]
//		[TestCase(50, 90)]
//		public void GetGrade_InputFromTestCase2_OutputsF(int a, int b)
//		{
//			//Arrange
//			grading.Score = a;
//			grading.AttendancePercentage = b;
//			//Act
//			var result = grading.GetGrade();
//			//Assert
//			Assert.That(result, Is.EqualTo("F"));
//			Assert.AreEqual("F", result);
//		}

//		[Test]
//		[TestCase(95, 90,ExpectedResult ="A")]
//		[TestCase(85, 90, ExpectedResult = "B")]
//		[TestCase(65, 90, ExpectedResult = "C")]
//		[TestCase(95, 65, ExpectedResult = "B")]
//		[TestCase(95, 55, ExpectedResult = "F")]
//		[TestCase(65, 55, ExpectedResult = "F")]
//		[TestCase(50, 90, ExpectedResult = "F")]
//		public string GetGrade_InputMultiple_Outputs(int a, int b)
//		{
//			//Arrange
//			grading.Score = a;
//			grading.AttendancePercentage = b;
//			//Act
//			return grading.GetGrade();		

//		}
//	}
//}
