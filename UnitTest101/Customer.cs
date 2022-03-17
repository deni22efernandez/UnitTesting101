using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest101
{
	public class Customer
	{
		public string Greeting { get; set; }
		public int Discount { get; set; } = 15;
		public string GreetCustomer(string Name, string Lastname)
		{
			Greeting = $"Hello {Name} {Lastname}";
			Discount = 20;
			return Greeting;
		}
	}
}
