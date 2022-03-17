using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTest101
{
	[TestFixture]
	public class CustomerNUnitTests
	{
		private Customer customer;

		[SetUp]
		public void Setup()//constructor
		{
			customer = new Customer();
		}

		[Test]
		public void GreetCustomer_InputTwoStrings_OutputString()
		{
			//Arrange
			//Customer customer = new Customer();
			//Act
			string greet = customer.GreetCustomer("Denisse", "Fernandez");
			//Assert
			Assert.That(greet, Is.EqualTo("Hello Denisse Fernandez"));
		}

		[Test]
		[TestCase("Denisse", "Fernandez", ExpectedResult = "Hello Denisse Fernandez")]
		public string GreetCustomer_InputTwoStrings_OutputString1(string a, string b)
		{
			//Arrange
			//Customer customer = new Customer();
			//Act
			return customer.GreetCustomer(a,b);
		}
		[Test]
		public void GreetCustomer_InputTwoStrings_OutputString_RandomValidations()
		{
			//Arrange
			//Customer customer = new Customer();
			//Act
			string greet = customer.GreetCustomer("Denisse", "Fernandez");
			//Assert
			//Assert.That(greet, Is.EqualTo("Hello Denisse Fernandez"));
			Assert.AreEqual("Hello Denisse Fernandez", greet);

			//Greet contiene Hello
			Assert.That(customer.Greeting, Does.Contain("Hello"));
			//Contain es case sensitive, para desactivarlo
			Assert.That(greet, Does.Contain("hello").IgnoreCase);

			//Greet comienza con hello
			Assert.That(greet, Does.StartWith("Hello"));

			//Greet termina con Fernandez
			Assert.That(greet, Does.EndWith("Fernandez"));

			//Regex
			Assert.That(greet, Does.Match("Hello [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
		}

		[Test]
		public void GreetCustomer_NotCallMethod_OutputNull()
		{
			//Arrange
			//Customer customer = new Customer();
			//Act

			//Assert
			Assert.IsNull(customer.Greeting);
		}
		[Test]
		public void GreetCustomer_CheckDiscount_OutputBetweenGivenRange()
		{
			//Arrange

			//Act
			var result = customer.Discount;
			//Assert
			Assert.That(result, Is.InRange(15, 25));
		}
	}
}
