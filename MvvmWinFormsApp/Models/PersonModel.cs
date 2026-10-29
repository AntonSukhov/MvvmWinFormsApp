using MvvmWinFormsApp.Common;

namespace MvvmWinFormsApp.Models
{
    public class PersonModel : DynamicNotifyPropertyChangedBase
    {
        public int Id
        {
            get => GetValue<int>(nameof(Id));
            set => SetValue(value, nameof(Id));
        }

        public string Name
        {
            get => GetValue<string>(nameof(Name));
            set => SetValue(value, nameof(Name));
        }

        public int Age
        {
            get => GetValue<int>(nameof(Age));
            set => SetValue(value, nameof(Age));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}