using Expenses.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Expenses.Views
{
	public partial class MainPage : ContentPage
	{
		ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();
		public MainPage()
		{
			InitializeComponent();
			InitList();
		}
		private void InitList()
		{
			expensesList.ItemsSource = items;
			expensesList.ItemSelected += ExpensesListItemSelected;
			input.Completed += InputCompleted;
		}

		private void ExpensesListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			expensesList.SelectedItem = null;
		}

		private void InputCompleted(object sender, EventArgs e)
		{
			if(input.Text != "")
			{
				AddItem();
				input.Focus();
			}
		}
		private void SubmitClicked(object sender, EventArgs e)
		{
			AddItem();
		}
		private void AddItem()
		{
			items.Add(new ItemModel { Id = items.Count, Price = input.Text });
			input.Text = "";
		}
	}
}
