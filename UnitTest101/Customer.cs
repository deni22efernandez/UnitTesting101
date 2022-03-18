using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest101
{
	public class Customer
	{
		public string Greeting { get; set; }
		public int Discount { get; set; } = 15;
		public int OrderTotal { get; set; }
		public string GreetCustomer(string Name, string Lastname)
		{
			if (String.IsNullOrEmpty(Name))//for assert.exception
				throw new ArgumentException("Name is required!"); 

			Greeting = $"Hello {Name} {Lastname}";
			Discount = 20;
			return Greeting;
		}
		public CustomerType GetTypeOfCustomer()
		{
			if (OrderTotal < 100)
				return new BasicCustomer();
			else
				return new PlatinumCustomer();
		}
	}
	public class CustomerType { }
	public class BasicCustomer: CustomerType { }
	public class PlatinumCustomer : CustomerType { }

}
