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
		string MessageWithReturnString(string str);
		bool LogWithOutputResult(string str, out string anotherString);
		bool LogWithReference(ref Customer customer);
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

		public bool LogWithOutputResult(string str, out string anotherString)
		{
		    anotherString = "Logging " + str;
			return true;
		}

		public bool LogWithReference(ref Customer customer)
		{
			return true;
		}

		public void Message(string mssg)
		{
			Console.WriteLine(mssg);
		}

		public string MessageWithReturnString(string str)
		{
			Console.WriteLine(str);
			return str;
		}
	}
}
