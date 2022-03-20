
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace UnitTest101
//{
//	[TestFixture]
//	public class FibonacciXUnitTests
//	{
//		private Fibonacci fibonacci;

//		[SetUp]
//		public void SetUp()
//		{
//			fibonacci = new Fibonacci();
//		}

//		[Test]
//		public void GetFiboSeries_InputRange1_MultipleAsserts()
//		{
//			//Arrange
//			List<int> expectedResults = new List<int>() { 0 };
//			fibonacci.Range = 1;
//			//Act
//			var result = fibonacci.GetFiboSeries();
//			//Assert
//			Assert.Multiple(() =>
//			{
//				Assert.That(result, Is.Not.Empty);
//				Assert.That(result, Is.Ordered);
//				Assert.That(result, Is.EquivalentTo(expectedResults));
//			});
//		}

//		[Test]
//		public void GetFiboSeries_InputRange6_MultipleAsserts()
//		{
//			//Arrange
//			List<int> expectedResults = new List<int>() { 0,1,1,2,3,5 };
//			fibonacci.Range = 6;
//			//Act
//			var result = fibonacci.GetFiboSeries();
//			//Assert
//			Assert.Multiple(() =>
//			{
//				Assert.That(result, Does.Contain(3));
//				//Assert.That(result.Count.Equals(6));
//				Assert.That(result.Count, Is.EqualTo(6));
//				//Assert.That(result, Does.Not.Contains(4));
//				Assert.That(result, Has.No.Member(4));
//				Assert.That(result, Is.EquivalentTo(expectedResults));
//			});
//		}
//	}
//}
