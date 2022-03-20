
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest101
{
	public class FibonacciXUnitTests
	{
		private Fibonacci fibonacci;
		public FibonacciXUnitTests()
		{
			fibonacci = new Fibonacci();
		}

		[Fact]
		public void GetFiboSeries_InputRange1_MultipleAsserts()
		{
			//Arrange
			List<int> expectedResults = new List<int>() { 0 };
			fibonacci.Range = 1;
			//Act
			var result = fibonacci.GetFiboSeries();
			//Assert
			Assert.NotEmpty(result);
			Assert.Equal(result.OrderBy(x => x), result);
			Assert.Equal(expectedResults, result);
			//iagual al de arriba
			Assert.True(result.SequenceEqual(expectedResults));//comparar dos colecciones
		}

		[Fact]
		public void GetFiboSeries_InputRange6_MultipleAsserts()
		{
			//Arrange
			List<int> expectedResults = new List<int>() { 0, 1, 1, 2, 3, 5 };
			fibonacci.Range = 6;
			//Act
			var result = fibonacci.GetFiboSeries();
			//Assert

			Assert.Contains(3,result);
			//Assert.That(result.Count.Equals(6));
			Assert.Equal(6, result.Count);
			//Assert.That(result, Does.Not.Contains(4));
			Assert.DoesNotContain(4, result);
			Assert.True(result.SequenceEqual(expectedResults));
		}
	}
}
