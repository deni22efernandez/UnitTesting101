
using System;
using System.Collections.Generic;
using UnitTest101;
using Xunit;

namespace UnitTest101NUnitTest
{	
	public class CalculationXUnitTests
	{
		private Calculation calc;
		public CalculationXUnitTests()
		{
			calc = new Calculation();
		}

		[Fact]
		public void AddNumbers_TwoIntergers_ReturnsCorrectCalculation()
		{
			//Arrange
			 
			//Act
			int result = calc.AddNumbers(1, 1);
			//Assert
			Assert.Equal(2, result);
		}
		[Fact]
		public void IsOddNumer_InputOddInterger_OutputsTrue()
		{
			//Arrange
			
			//Act
			bool result = calc.IsOddNumber(1);
			//Assert
			Assert.True(result);
		}
		[Fact]
		public void IsOddNumer_InputEvenInterger_OutputsFalse()
		{
			//Arrange
			
			//Act
			bool result = calc.IsOddNumber(2);
			//Assert
			Assert.False(result);
		}
		[Theory]
		[InlineData(2)]
		[InlineData(4)]
		public void IsOddNumer_InputEvenInterger_OutputsFalse2(int a)//parametro del test case
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			bool result = calc.IsOddNumber(a);//parametro del test case
			//Assert
			Assert.False(result);
			//Assert.That(result, Is.EqualTo(false));
		}

		[Theory]
		[InlineData(2,false)]
		[InlineData(1,true)]
		public void IsOddNumer_InputInterger_OutputsTrueIfOdd(int a, bool expected)
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			var result = calc.IsOddNumber(a);
			Assert.Equal(result, expected);
											 
		}

		//[Theory]
		//[InlineData(1.1, 2.1)]//returns 3.2
		//[InlineData(1.1, 2.5)]// 3.6
		//[InlineData(1.1, 2.9)]// 4
		//public void AddDoubleNumbers_InputTwoDoubleValues_ReturnsDoubleValue(double a, double b)
		//{
		//	//Arrange
		//	//Calculation calc = new Calculation();
		//	//Act
		//	double result = calc.AddDoubleNumbers(a, b);
		//	//Assert
		//	Assert.Equal(3.2, result,.8);
		//	//Assert.That(result, Is.EqualTo(3.2));
		//}

		//[Fact]
		//public void GetOddNumbers_InputMinMaxRange_OutputsOddsNumbrsBetweenRange()
		//{
		//	//Arrange
		//	List<int> expectedListOfOddNmbrs = new List<int>() { 1, 3, 5, 7, 9 };//inicializo la lista esperada
		//	//Act
		//	var result = calc.GetOddNumbers(0, 10);
		//	//Assert
		//	Assert.That(result, Is.EquivalentTo(expectedListOfOddNmbrs));

		//	//igual a usar isEquivalentTo el orden de las variables cambia
		//	//Assert.AreEqual(expectedListOfOddNmbrs, result); 

		//	//la coleccion contiene un valor x
		//	//Assert.Contains(7, result);

		//	//la coleccion contiene un valor x (igual al assert anterior)
		//	Assert.That(result, Does.Contain(7));

		//	//todos los valores de la colleccion son unicos
		//	Assert.That(result, Is.Unique);

		//	//la coleccion esta ordenada d forma ascendente
		//	Assert.That(result, Is.Ordered);

		//	//la coleccion esta ordenada d forma descendiente
		//	//Assert.That(result, Is.Ordered.Descending);

		//	//la colleccion no esta vacia
		//	Assert.That(result, Is.Not.Empty);

		//	//la coleccion tiene 5 elementos
		//	Assert.That(result.Count, Is.EqualTo(5));

		//	//la colleccion no contiene el numero 2
		//	Assert.That(result, Has.No.Member(2));
			
			
		//}

	}
}
