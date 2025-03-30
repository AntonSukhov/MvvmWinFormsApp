using MvvmWinFormsApp.Common;

namespace MvvmWinFormsApp.Models
{
    public class PersonModel: NotifyPropertyChangedBase
    {
        private int _id;
        private string _name = string.Empty;
        private int _age;

        public int Id 
        {
            get => _id;
            set => SetValue(ref _id, value, nameof(Id));
        }

        public string Name 
        { 
            get => _name; 
            set => SetValue(ref _name, value, nameof(Name)); 
        }

        public int Age
        {
            get => _age;
            set => SetValue(ref _age, value, nameof(Age));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
