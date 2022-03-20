using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest101
{
	[TestFixture]
	public class BankAccountNUnitTest
	{
		private BankAccount bankAccount;

		[SetUp]
		public void Setup()
		{
			
		}
		[Test]
		public void Deposit_InputAmount_OutputsTrue()
		{
			//Arrange
			var logBookMock = new Mock<ILogger>();
			bankAccount = new BankAccount(logBookMock.Object);
			//Act
			var result=bankAccount.Deposit(111);
			//Assert
			Assert.IsTrue(result);
			Assert.That(result, Is.True);
			Assert.AreEqual(true, result);
		}

		[Test]
		public void WithDraw_InputWitdraw100WithBalance200_OutputsTrue()
		{
			//Arrange
			var logBookMock = new Mock<ILogger>();
			//LogToDb si le paso al menos un string me debe devolver true
			logBookMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
			//LogBalanceAfterWithdrawal si recibe un int mayor o igual a cero debe retornar true
			logBookMock.Setup(x => x.LogBalanceAfterWithDrawal(It.Is<int>(x=>x>=0))).Returns(true);
			var bankAccount = new BankAccount(logBookMock.Object);

			//Act
			bankAccount.Deposit(200);
			var result = bankAccount.Withdraw(100);
			//Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void WithDraw_InputWitdraw300WithBalance100_OutputsFalse()
		{
			//Arrange
			var logBookMock = new Mock<ILogger>();
			//LogBalanceAfterWithdrawal si recibe un int menor a cero debe retornar false
			logBookMock.Setup(x => x.LogBalanceAfterWithDrawal(It.Is<int>(x => x < 0))).Returns(false);
			//lo mismo usando InRange
			logBookMock.Setup(x => x.LogBalanceAfterWithDrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive)));

			var bankAccount = new BankAccount(logBookMock.Object);
			bankAccount.Balance = 100;

			//Act			
			var result = bankAccount.Withdraw(300);
			//Assert
			Assert.IsFalse(result);
		}

		[Test]
		
		public void MessageWithReturnString_InputString_OutputsString()
		{
			//test a method in mock withdout implementing it
			//Arrange
			var logBookMock = new Mock<ILogger>();
			//MessageWithReturnString must return any string
			logBookMock.Setup(x => x.MessageWithReturnString(It.IsAny<string>())).Returns((string str)=>str);
			string desiredOutput = "any string";
			//Act
			var result = logBookMock.Object.MessageWithReturnString("any string");
			//Assert
			Assert.That(result, Is.TypeOf<string>());
			Assert.That(result, Is.EqualTo(desiredOutput));
		}

		[Test]

		public void MessageWithReturnString_InputString_OutputsStringII()
		{
			//igual al anterior pero sin act
			//Arrange
			var logBookMock = new Mock<ILogger>();
			//MessageWithReturnString must return any string
			logBookMock.Setup(x => x.MessageWithReturnString(It.IsAny<string>())).Returns((string str) => str);
			string desiredOutput = "any string";			
			
			//Assert
			Assert.That(logBookMock.Object.MessageWithReturnString("any string"), Is.TypeOf<string>());
			Assert.That(logBookMock.Object.MessageWithReturnString("any string"), Is.EqualTo(desiredOutput));
		}
		[Test]
		public void LogWithOutputResult_InputString_OutputsTrueAndString()
		{
			//Arrange
			var LogBookMoq = new Mock<ILogger>();
			string desiredOutput = "Logging something";
			LogBookMoq.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
			var result = "";

			//Assert
			Assert.IsTrue(LogBookMoq.Object.LogWithOutputResult("something", out result));			
			Assert.That(result, Is.EqualTo(desiredOutput));

		}
		[Test]
		public void LogWithReference_InputCustomerReference_OutputsTrue()
		{
			//Arrange
			var LogBookMoq = new Mock<ILogger>();
			var reference = new Customer();
			var reference2 = new Customer();
			//el test pasa siempre q el metodo reciba una variable llamada reference
			LogBookMoq.Setup(x => x.LogWithReference(ref reference)).Returns(true);
			Assert.IsTrue(LogBookMoq.Object.LogWithReference(ref reference));
			//es false x el nombre de la variable
			Assert.IsFalse(LogBookMoq.Object.LogWithReference(ref reference2));
		}
		[Test]
		public void LogBookProperties_SetAndGetSeverityLogType()
		{
			//Arrange
			var LogBookMoq = new Mock<ILogger>();
			
			LogBookMoq.Setup(x => x.LogSeverity).Returns(10);
			LogBookMoq.Setup(x => x.LogType).Returns("warning");
			//sobreescribo el setup, debo hacerlo para todas las prop sino c setean en null
			LogBookMoq.SetupAllProperties();
			LogBookMoq.Object.LogSeverity = 100;
			LogBookMoq.Object.LogType = "w";

			//Assert
			Assert.That(LogBookMoq.Object.LogSeverity, Is.EqualTo(100));
			Assert.That(LogBookMoq.Object.LogType, Is.EqualTo("w"));
		}
		
	}
}
