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
			inputN.Text = "";
			inputP.Text = "";
			inputD.Text = "";
			inputN.Completed += InputNCompleted;
			inputP.Completed += InputPCompleted;
			inputD.Completed += InputDCompleted;
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
		private void InputPCompleted(object sender, EventArgs e)
		{
			if(inputP.Text != "" && inputN.Text != "")
				inputD.Focus();
		}
		private void InputDCompleted(object sender, EventArgs e)
		{
			if (inputP.Text != "" && inputN.Text != "" && inputD.Text != "")
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
			if (inputP.Text != "" && inputN.Text != "" && inputD.Text != "")
			{
				items.Add(new ItemModel { Id = items.Count, Name = inputN.Text, Price = inputP.Text, Date = inputD.Text });
				inputN.Text = "";
				inputP.Text = "";
				inputD.Text = "";
			}
			else
			{
				DisplayAlert("UWAGA!","Upewnij się, że wszystkie pola są uzupełnione","OK");
			}
		}
	}
}
