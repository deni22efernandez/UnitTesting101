using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest101;

namespace UnitTest101MSTest
{
	[TestClass]
	public class CalculationMSTests
	{
		[TestMethod]
		public void AddNumbers_TwoIntergers_ReturnsCorrectCalculation()
		{
			//Arrange
			Calculation calc = new Calculation();
			//Act
			int result = calc.AddNumbers(1 , 1);
			//Assert
			Assert.AreEqual(2, result);
		}
	}
}
