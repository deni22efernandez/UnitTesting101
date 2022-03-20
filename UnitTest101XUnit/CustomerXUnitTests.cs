
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace UnitTest101
{
	public class CustomerXUnitTests
	{
		private Customer customer;

		public CustomerXUnitTests()
		{
			customer = new Customer();
		}

		[Fact]
		public void GreetCustomer_InputTwoStrings_OutputString()
		{
			//Arrange
			//Customer customer = new Customer();
			//Act
			string greet = customer.GreetCustomer("Denisse", "Fernandez");
			//Assert
			Assert.Equal("Hello Denisse Fernandez", greet);
		}

		[Theory]
		[InlineData("Denisse", "Fernandez", "Hello Denisse Fernandez")]
		public void GreetCustomer_InputTwoStrings_OutputString1(string a, string b, string expected)
		{
			//Arrange
			//Customer customer = new Customer();
			//Act
			var result = customer.GreetCustomer(a, b);
			//Assert
			Assert.Equal(expected, result);
		}
		[Fact]
		public void GreetCustomer_InputTwoStrings_OutputString_RandomValidations()
		{
			//Arrange
			//Customer customer = new Customer();
			//Act
			string greet = customer.GreetCustomer("Denisse", "Fernandez");
			//Assert
			Assert.Equal("Hello Denisse Fernandez", greet);

			//Greet contiene Hello
			Assert.Contains("Hello", customer.Greeting);

			//Greet comienza con hello
			Assert.StartsWith("Hello", greet);

			//Greet termina con Fernandez
			Assert.EndsWith("Fernandez", greet);

			//Regex
			Assert.Matches("Hello [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", greet);
		}

		[Fact]
		public void GreetCustomer_NotCallMethod_OutputNull()
		{
			//Arrange
			//Customer customer = new Customer();
			//Act

			//Assert
			Assert.Null(customer.Greeting);
		}
		[Fact]
		public void GreetCustomer_CheckDiscount_OutputBetweenGivenRange()
		{
			//Arrange

			//Act
			var result = customer.Discount;
			//Assert
			Assert.InRange(result, 15, 25);
		}

		
		[Fact]
		public void GreetCustomer_InputTwoStrings_OutputString_MultipleAsserts()
		{
			string greet = customer.GreetCustomer("Denisse", "Fernandez");

			//Assert			
			Assert.Equal("Hello Denisse Fernandez", greet);
			Assert.Contains("Hello", customer.Greeting);
			Assert.StartsWith("Hello", greet);
			Assert.EndsWith("Fernandez", greet);
			Assert.Matches("Hello [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", greet);


		}

		//EXCEPTIONS
		[Fact]
		public void GreetCustomer_InputNameIsNullOrEmpty_OutputsException()
		{
			//Arrange
			var excep = Assert.Throws<ArgumentException>(() => customer.GreetCustomer("", "Fernandez"));

			//Assert comparando mensaje de la excepcion
			Assert.Equal("Name is required!", excep.Message);

			//Assert sin comparacion de mensaje, solo checkeo el tipo d la exception
			Assert.Throws<ArgumentException>(() => customer.GreetCustomer("", "Fernandez"));

		}

		//ASSERT TYPEOF OBJECT 
		[Fact]
		public void GetTypeOfCustomer_InputLessThan100_OutputsBasicCustomerType()
		{
			//Arrange
			customer.OrderTotal = 99;
			//Act
			var result = customer.GetTypeOfCustomer();
			//Assert
			Assert.IsType<BasicCustomer>(result);
		}

		[Fact]
		public void GetTypeOfCustomer_InputMoreThan100_OutputsPlatinumCustomerType()
		{
			//Arrange
			customer.OrderTotal = 999;
			//Act
			var result = customer.GetTypeOfCustomer();
			//Assert
			Assert.IsType<PlatinumCustomer>(result);
		}


	}
}
