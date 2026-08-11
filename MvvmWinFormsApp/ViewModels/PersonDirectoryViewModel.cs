using MvvmWinFormsApp.Commands;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Models;
using MvvmWinFormsApp.Services;
using System;
using System.Collections.Generic;

namespace MvvmWinFormsApp.ViewModels
{
    public class PersonDirectoryViewModel : NotifyPropertyChangedBase
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly IDataSourceService _dataSourceService;

        private PersonModel _person;
        private IList<PersonModel> _persons;

        public IList<PersonModel> Persons
        {
            get => _persons;
            set
            {
                if (SetProperty(ref _persons, value, nameof(Persons)))
                {
                    ShowPersonCommand?.RaiseCanExecuteChanged();
                }
            }
        }

        public PersonModel Person
        {
            get => _person;
            set
            {
                if (SetProperty(ref _person, value, nameof(Person)))
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
