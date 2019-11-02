using System;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoItemPage : ContentPage
	{
		public TodoItemPage()
		{
			InitializeComponent();
		}

		protected override async void OnDisappearing ()
		{
			var todoItem = (TodoItem)BindingContext;
			if (todoItem.IsExisting)
				await App.Database.SaveItemAsync(todoItem);
		}

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.Database.SaveItemAsync(todoItem);
			await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var todoItem = (TodoItem)BindingContext;
			await App.Database.DeleteItemAsync(todoItem);
			await Navigation.PopAsync();
		}

        async void Switch_ToggledAsync(object sender, ToggledEventArgs e)
        {
			// Part 13: Effects
            if (e.Value == false)
			{
				// scale down to original
			}
			else if (e.Value == true)
			{
				// fade in
				// scale up to 2x
				// fade out
			}
        }
    }
}
