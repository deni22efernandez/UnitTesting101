using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest101
{
	public class BankAccount
	{
		public double Balance { get; set; }
		public BankAccount()
		{
			Balance = 0;
		}
		public bool Deposit(double amount)
		{
			Balance += amount;
			return true;
		}
		public bool Withdraw(double amount)
		{
			if (Balance >= amount)
			{
				Balance -= amount;
				return true;
			}				
			else
				return false;
		}
		public double GetBalance()
		{
			return Balance;
		}
	}
}
