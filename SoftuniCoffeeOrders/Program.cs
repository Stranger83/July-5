using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniCoffeeOrders
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			decimal totalPrice = 0.0M;
			for (int i = 0; i < n; i++)
			{
				decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
				string[] orderDate = Console.ReadLine().Split('/');
				var month = int.Parse(orderDate[1]);
				var year = int.Parse(orderDate[2]);
				int capsuleCount = int.Parse(Console.ReadLine());
				int days = DateTime.DaysInMonth(year, month);
				decimal orderPrice = days * (decimal)capsuleCount * pricePerCapsule;
				Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
				totalPrice += orderPrice;
			}
			Console.WriteLine($"Total: ${totalPrice:f2}");
		}
	}
}