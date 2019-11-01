using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace Todo
{
	public partial class TodoListPage : ContentPage
	{
		public TodoListPage()
		{
			InitializeComponent();
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TodoItemPage
			{
				BindingContext = new TodoItem()
			});
		}

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
                ((ListView)sender).SelectedItem = null;
            }
        }

        //// Step 7b: Uncomment this, and comment out above!
        //async void OnListItemSelected(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.CurrentSelection.FirstOrDefault() != null)
        //        await Navigation.PushAsync(new TodoItemPage
        //        {
        //            BindingContext = e.CurrentSelection.FirstOrDefault() as TodoItem
        //        });
        //}

    }
}
