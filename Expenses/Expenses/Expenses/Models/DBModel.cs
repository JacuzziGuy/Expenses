using System;
using SQLite;

namespace Expenses.Models
{
	public class DBModel
	{
		public static SQLiteConnection DatabasePath()
		{
			return new SQLiteConnection(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ExpensesDataBase.sqlite");
		}
	}
}
