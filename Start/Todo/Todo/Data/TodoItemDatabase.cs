using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;

namespace Todo
{
	public class TodoItemDatabase
	{
		readonly SQLiteAsyncConnection database;

		public ObservableCollection<TodoItem> Items { get; } = new ObservableCollection<TodoItem> ();

		public TodoItemDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<TodoItem>().Wait();
		}

		public async Task LoadItemsAsync()
		{
			var list = await database.Table<TodoItem>().ToListAsync();
			Items.Clear();
			foreach (var item in list)
				Items.Add(item);
		}

		public Task<List<TodoItem>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
		}

		public Task<TodoItem> GetItemAsync(int id)
		{
			return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(TodoItem item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				Items.Add(item);
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(TodoItem item)
		{
			Items.Remove(item);
			return database.DeleteAsync(item);
		}
	}
}

