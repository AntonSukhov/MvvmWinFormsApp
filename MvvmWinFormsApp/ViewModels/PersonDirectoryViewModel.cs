using MvvmWinFormsApp.Commands;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Models;
using MvvmWinFormsApp.Services;
using System;
using System.Collections.Generic;

namespace MvvmWinFormsApp.ViewModels
{
    public class PersonDirectoryViewModel : DynamicNotifyPropertyChangedBase
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly IDataSourceService _dataSourceService;

        public IList<PersonModel> Persons
        {
            get => GetValue<IList<PersonModel>>(nameof(Persons));
            set
            {
                if (SetValue(value, nameof(Persons)))
                {
                    ShowPersonCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        public PersonModel Person
        {
            get => GetValue<PersonModel>(nameof(Person));
            set
            {
                if (SetValue(value, nameof(Person)))
                {
                    ShowPersonCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand ShowPersonCommand { get; }

        public PersonDirectoryViewModel(IMessageBoxService messageBoxService, IDataSourceService dataSourceService)
        {
            _messageBoxService = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));
            _dataSourceService = dataSourceService ?? throw new ArgumentNullException(nameof(dataSourceService));

            Persons = _dataSourceService.GetPersons();

            ShowPersonCommand = new RelayCommand(ExecuteShowPersonCommand, CanExecuteShowPersonCommand);
        }

        private void ExecuteShowPersonCommand(object parameter)
        {
            if (Person != null)
            {
                _messageBoxService.ShowMessage($"{Person.Id} {Person.Name} {Person.Age}", "Просмотр персоны");
            }

        }

        private bool CanExecuteShowPersonCommand(object parameter) => Person != null;
    }
}
