
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest101
{
	public class GradingCalculatorXUnitTests
	{
		private GradingCalculator grading;

		public GradingCalculatorXUnitTests()
		{
			grading = new GradingCalculator();
		}

		[Fact]
		public void GetGrade_InputScore95Attendance90_OutputsA()
		{
			//Arrange
			grading.Score = 95;
			grading.AttendancePercentage = 90;
			//Act
			var result = grading.GetGrade();
			//Assert
			Assert.Equal("A", result);
		}
		[Fact]
		public void GetGrade_InputScore85Attendance90_OutputsB()
		{
			//Arrange
			grading.Score = 85;
			grading.AttendancePercentage = 90;
			//Act
			var result = grading.GetGrade();
			//Assert
			Assert.Equal("B", result);
		}
		[Fact]
		public void GetGrade_InputScore65Attendance90_OutputsC()
		{
			//Arrange
			grading.Score = 65;
			grading.AttendancePercentage = 90;
			//Act
			var result = grading.GetGrade();
			//Assert
			Assert.Equal("C", result);
		}
		[Fact]
		public void GetGrade_InputScore95Attendance65_OutputsB()
		{
			//Arrange
			grading.Score = 95;
			grading.AttendancePercentage = 65;
			//Act
			var result = grading.GetGrade();
			//Assert
			Assert.Equal("B", result);
		}
		[Theory]
		[InlineData(95, 55, "F")]
		[InlineData(65, 55, "F")]
		[InlineData(50, 90, "F")]
		public void GetGrade_InputFromTestCase1_OutputsF(int a, int b, string c)
		{
			//Arrange
			grading.Score = a;
			grading.AttendancePercentage = b;
			//Act
			var result = grading.GetGrade();
			//Assert			
			Assert.Equal(c, result);
		}

		[Theory]
		[InlineData(95, 55)]
		[InlineData(65, 55)]
		[InlineData(50, 90)]
		public void GetGrade_InputFromTestCase2_OutputsF(int a, int b)
		{
			//Arrange
			grading.Score = a;
			grading.AttendancePercentage = b;
			//Act
			var result = grading.GetGrade();
			//Assert
			Assert.Equal("F", result);
		}

		[Theory]
		[InlineData(95, 90, "A")]
		[InlineData(85, 90, "B")]
		[InlineData(65, 90, "C")]
		[InlineData(95, 65, "B")]
		[InlineData(95, 55, "F")]
		[InlineData(65, 55, "F")]
		[InlineData(50, 90, "F")]
		public void GetGrade_InputMultiple_Outputs(int a, int b, string c)
		{
			//Arrange
			grading.Score = a;
			grading.AttendancePercentage = b;
			//Act
			var result = grading.GetGrade();
			//Assert
			Assert.Equal(c, result);
		}
	}
}
