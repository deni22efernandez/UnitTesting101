using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest101
{
	public class BankAccount
	{
		public double Balance { get; set; }
		private ILogger _logBook { get; set; }
		public BankAccount(ILogger logBook)
		{
			Balance = 0;
			_logBook = logBook;
		}
		public bool Deposit(double amount)
		{
			_logBook.Message("Begin deposit transaction");
			_logBook.LogSeverity = 1; 
			var temp = _logBook.LogSeverity; 
			Balance += amount;
			return true;
		}
		public bool Withdraw(double amount)
		{
			if (Balance >= amount)
			{
				_logBook.LogToDb("Withdrawal amount:" + amount.ToString());
				Balance -= amount;
				return _logBook.LogBalanceAfterWithDrawal((int)Balance);
				
			}
			else
				return _logBook.LogBalanceAfterWithDrawal((int)Balance - (int)amount);
				
		}
		public double GetBalance()
		{
			return Balance;
		}
	}
}
