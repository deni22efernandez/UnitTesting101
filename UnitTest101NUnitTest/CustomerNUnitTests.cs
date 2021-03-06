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

		//ASSERT MULTIPLE
		[Test]
		public void GreetCustomer_InputTwoStrings_OutputString_MultipleAsserts()
		{
			string greet = customer.GreetCustomer("Denisse", "Fernandez");

			//Assert
			Assert.Multiple(()=> 
			{
				Assert.That(greet, Is.EqualTo("Hello Denisse Fernandez"));
				Assert.AreEqual("Hello Denisse Fernandez", greet);
				Assert.That(customer.Greeting, Does.Contain("Hello"));
				Assert.That(greet, Does.Contain("hello").IgnoreCase);
				Assert.That(greet, Does.StartWith("Hello"));
				Assert.That(greet, Does.EndWith("Fernandez"));
				Assert.That(greet, Does.Match("Hello [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
			});
			
		}

		//EXCEPTIONS
		[Test]
		public void GreetCustomer_InputNameIsNullOrEmpty_OutputsException()
		{
			//Arrange
			var excep = Assert.Throws<ArgumentException>(() => customer.GreetCustomer("", "Fernandez"));

			//Assert comparando mensaje de la excepcion
			Assert.AreEqual("Name is required!", excep.Message);
			Assert.That(excep.Message, Is.EqualTo("Name is required!"));

			Assert.That(() => customer.GreetCustomer("", "Fernandez"), 
				Throws.ArgumentException.With.Message.EqualTo("Name is required!"));

			//Assert sin comparacion de mensaje, solo checkeo el tipo d la exception
			Assert.Throws<ArgumentException>(()=>customer.GreetCustomer("", "Fernandez"));
			Assert.That(() => customer.GreetCustomer("", "Fernandez"), Throws.ArgumentException);
			
		}

		//ASSERT TYPEOF OBJECT 
		[Test]
		public void GetTypeOfCustomer_InputLessThan100_OutputsBasicCustomerType()
		{
			//Arrange
			customer.OrderTotal = 99;
			//Act
			var result = customer.GetTypeOfCustomer();
			//Assert
			Assert.That(result, Is.TypeOf<BasicCustomer>());
		}

		[Test]
		public void GetTypeOfCustomer_InputMoreThan100_OutputsPlatinumCustomerType()
		{
			//Arrange
			customer.OrderTotal = 999;
			//Act
			var result = customer.GetTypeOfCustomer();
			//Assert
			Assert.That(result, Is.TypeOf<PlatinumCustomer>());
		}


	}
}
