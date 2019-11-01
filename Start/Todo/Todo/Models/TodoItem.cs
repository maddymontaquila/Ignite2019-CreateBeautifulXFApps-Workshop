using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using SQLite;

namespace Todo
{
	public class TodoItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public bool IsNew => (ID == 0);
		public bool IsExisting => !IsNew;

		string name;
		public string Name {
			get => name;
			set => SetProperty (ref name, value);
		}

		string notes;
		public string Notes {
			get => notes;
			set => SetProperty (ref notes, value);
		}

		bool done;
		public bool Done {
			get => done;
			set => SetProperty (ref done, value);
		}

		void SetProperty<T> (ref T field, T value, [CallerMemberName] string name = null)
		{
			if (EqualityComparer<T>.Default.Equals (field, value))
				return;

			field = value;
			PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
		}
	}
}

