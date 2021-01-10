using SQLite;

namespace Expenses.Models
{
	[Table("ItemModel")]
	public class ItemModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Price { get; set; }
		public string Date { get; set; }
		public string Display { get { return $"Na: {Name},\nCena: {Price}zł,\nZ dnia: {Date}"; } }
	}
}
