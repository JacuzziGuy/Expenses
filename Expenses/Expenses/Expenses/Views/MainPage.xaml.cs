using Expenses.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SQLite;

namespace Expenses.Views
{
	public partial class MainPage : ContentPage
	{
		#region Variables

		ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();
		SQLiteConnection db = DBModel.DatabasePath();

		#endregion
		public MainPage()
		{
			InitializeComponent();
			InitDB();
			InitList();
		}
		private void InitDB()
		{
			try
			{
				items = new ObservableCollection<ItemModel>(db.Query<ItemModel>("SELECT * FROM ItemModel"));
			}
			catch
			{
				db.CreateTable<ItemModel>();
			}
		}
		private void InitList()
		{
			expensesList.ItemsSource = items;
			expensesList.ItemSelected += ExpensesListItemSelected;
			inputN.Text = "";
			inputP.Text = "";
			inputD.Text = DateTime.Now.Day.ToString();
			inputM.Text = DateTime.Now.Month.ToString();
			inputY.Text = DateTime.Now.Year.ToString();
			inputN.Completed += InputNCompleted;
			inputD.Completed += InputDCompleted;
			inputM.Completed += InputMCompleted;
			inputY.Completed += InputYCompleted;
		}
		private void ExpensesListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			expensesList.SelectedItem = null;
		}
		private void InputNCompleted(object sender, EventArgs e)
		{
			if(inputN.Text != "")
				inputP.Focus();
		}
		private void InputDCompleted(object sender, EventArgs e)
		{
			if (inputP.Text != "" && inputN.Text != "" && inputD.Text != "")
				inputM.Focus();
		}
		private void InputMCompleted(object sender, EventArgs e)
		{
			if (inputP.Text != "" && inputN.Text != "" && inputD.Text != "" && inputM.Text != "")
				inputY.Focus();
		}
		private void InputYCompleted(object sender, EventArgs e)
		{
			if (inputP.Text != "" && inputN.Text != "" && inputD.Text != "" && inputM.Text != "" && inputY.Text != "")
			{
				AddItem();
				inputN.Focus();
			}
		}
		private void SubmitClicked(object sender, EventArgs e)
		{
			AddItem();
		}
		private void AddItem()
		{
			if (inputP.Text != "" && inputN.Text != "" && inputD.Text != "" && inputM.Text != "" && inputY.Text != "")
			{
				string day, month;
				if (inputD.Text.Length == 1)
					day = $"0{inputD.Text}";
				else
					day = inputD.Text;
				if (inputM.Text.Length == 1)
					month = $"0{inputM.Text}";
				else
					month = inputM.Text;
				var item = new ItemModel { Id = items.Count, Name = inputN.Text, Price = inputP.Text, Date = $"{day}.{month}.{inputY.Text}" };
				items.Add(item);
				db.Insert(item);
				inputN.Text = "";
				inputP.Text = "";
				inputD.Text = DateTime.Now.Day.ToString();
				inputM.Text = DateTime.Now.Month.ToString();
				inputY.Text = DateTime.Now.Year.ToString();
			}
			else
			{
				DisplayAlert("UWAGA!","Upewnij się, że wszystkie pola są uzupełnione","OK");
			}
		}
		private void DeleteClicked(object sender, EventArgs e)
		{
			ItemModel item = (sender as Button).BindingContext as ItemModel;
			items.Remove(item);
			db.Delete(item);
		}
	}
}
