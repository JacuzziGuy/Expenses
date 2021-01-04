using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.Models
{
	public class ItemModel
	{
		public int Id { get; set; }
		public string Price { get; set; }
		public string PriceDisplay { get { return Price + " zł"; } }
	}
}
