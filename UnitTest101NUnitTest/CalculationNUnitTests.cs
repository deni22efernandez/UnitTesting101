using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnitTest101;

namespace UnitTest101NUnitTest
{
	[TestFixture]
	public class CalculationNUnitTests
	{
		private Calculation calc;

		[SetUp]
		public void Setup()
		{
			calc = new Calculation();
		}

		[Test]
		public void AddNumbers_TwoIntergers_ReturnsCorrectCalculation()
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			int result = calc.AddNumbers(1, 1);
			//Assert
			Assert.AreEqual(2, result);
		}
		[Test]
		public void IsOddNumer_InputOddInterger_OutputsTrue()
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			bool result = calc.IsOddNumber(1);
			//Assert
			Assert.IsTrue(result);
			Assert.That(result, Is.EqualTo(true));// otra forma de decir is true
		}
		[Test]
		public void IsOddNumer_InputEvenInterger_OutputsFalse()
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			bool result = calc.IsOddNumber(2);
			//Assert
			Assert.IsFalse(result);
			Assert.That(result, Is.EqualTo(false));
		}
		[Test]
		[TestCase(2)]
		[TestCase(4)]
		public void IsOddNumer_InputEvenInterger_OutputsFalse(int a)//parametro del test case
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			bool result = calc.IsOddNumber(a);//parametro del test case
			//Assert
			//Assert.IsFalse(result);
			Assert.That(result, Is.EqualTo(false));
		}

		[Test]
		[TestCase(2, ExpectedResult = false)]
		[TestCase(1, ExpectedResult = true)]
		public bool IsOddNumer_InputInterger_OutputsTrueIfOdd(int a)
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			return calc.IsOddNumber(a);
											 
		}

		[Test]
		[TestCase(1.1, 2.1)]//returns 3.2
		[TestCase(1.1, 2.5)]// 3.6
		[TestCase(1.1, 2.9)]// 4
		public void AddDoubleNumbers_InputTwoDoubleValues_ReturnsDoubleValue(double a, double b)
		{
			//Arrange
			//Calculation calc = new Calculation();
			//Act
			double result = calc.AddDoubleNumbers(a, b);
			//Assert
			Assert.AreEqual(3.2, result, .8);
			Assert.That(result, Is.EqualTo(3.2));
		}

		[Test]
		public void GetOddNumbers_InputMinMaxRange_OutputsOddsNumbrsBetweenRange()
		{
			//Arrange
			List<int> expectedListOfOddNmbrs = new List<int>() { 1, 3, 5, 7, 9 };//inicializo la lista esperada
			//Act
			var result = calc.GetOddNumbers(0, 10);
			//Assert
			Assert.That(result, Is.EquivalentTo(expectedListOfOddNmbrs));

			//igual a usar isEquivalentTo el orden de las variables cambia
			//Assert.AreEqual(expectedListOfOddNmbrs, result); 

			//la coleccion contiene un valor x
			//Assert.Contains(7, result);

			//la coleccion contiene un valor x (igual al assert anterior)
			Assert.That(result, Does.Contain(7));

			//todos los valores de la colleccion son unicos
			Assert.That(result, Is.Unique);

			//la coleccion esta ordenada d forma ascendente
			Assert.That(result, Is.Ordered);

			//la coleccion esta ordenada d forma descendiente
			//Assert.That(result, Is.Ordered.Descending);

			//la colleccion no esta vacia
			Assert.That(result, Is.Not.Empty);

			//la coleccion tiene 5 elementos
			Assert.That(result.Count, Is.EqualTo(5));

			//la colleccion no contiene el numero 2
			Assert.That(result, Has.No.Member(2));
			
			
		}

	}
}
