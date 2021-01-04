using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.Models
{
	public class ItemModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Price { get; set; }
		public string Date { get; set; }
		public string Display { get { return $"{Name}, {Price}zł, {Date}"; } }
	}
}
