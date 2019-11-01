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

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

        async void Switch_ToggledAsync(object sender, ToggledEventArgs e)
        {
            // Step 17: Effects
            if (e.Value == false)
            {
                await doneImage.FadeTo(0, 1000);
                await doneImage.ScaleTo(1, 500);
            }
            else if (e.Value == true)
            {
                await doneImage.FadeTo(1, 1000);
                await doneImage.ScaleTo(2, 2000);
            }
        }
    }
}
