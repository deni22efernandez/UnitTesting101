using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest101
{
	public interface ILogger
	{
		void Message(string mssg);
		bool LogToDb(string mssg);
		bool LogBalanceAfterWithDrawal(int balanceAfterWithdrawal);
	}
	public class LogBook : ILogger
	{
		public bool LogBalanceAfterWithDrawal(int balanceAfterWithdrawal)
		{
			if (balanceAfterWithdrawal >= 0)
			{
				Console.WriteLine("Success");
				return true;
			}
			Console.WriteLine("Failure");
			return false;
		}

		public bool LogToDb(string mssg)
		{
			Console.WriteLine(mssg);
			return true;
		}

		public void Message(string mssg)
		{
			Console.WriteLine(mssg);
		}
	}
}
