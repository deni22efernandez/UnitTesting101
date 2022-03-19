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
	}
}
