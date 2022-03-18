using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest101
{
	public interface ILogger
	{
		void Message(string mssg);
	}
	public class LogBook : ILogger
	{
		public void Message(string mssg)
		{
			Console.WriteLine(mssg);
		}
	}
}
