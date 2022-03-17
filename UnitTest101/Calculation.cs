using System;
using System.Collections.Generic;

namespace UnitTest101
{
	public class Calculation
	{
		public List<int> OddNumbers { get; set; }
		public int AddNumbers(int a, int b)
		{
			return a + b;
		}
		public bool IsOddNumber(int number)
		{
			return number % 2 != 0;
		}
		public double AddDoubleNumbers(double a, double b)
		{
			return a + b;
		}
		public List<int> GetOddNumbers(int min, int max)
		{
			OddNumbers = new List<int>();
			
			for (int i = min; i < max; i++)
			{
				if (i % 2 != 0)
				{
					OddNumbers.Add(i);
				}
			}
			return OddNumbers;
		}

	}
}
