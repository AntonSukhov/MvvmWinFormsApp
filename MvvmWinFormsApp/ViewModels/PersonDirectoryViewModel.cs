using CommonServiceLocator;
using MvvmWinFormsApp.Commands;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Models;
using MvvmWinFormsApp.Services;
using System.Collections.Generic;

namespace MvvmWinFormsApp.ViewModels
{
    public class PersonDirectoryViewModel : NotifyPropertyChangedBase
    {
        #region Поля

        private readonly IMessageBoxService _messageBoxService;
        private readonly IDataSourceService _dataSourceService;

        private PersonModel _person;
        private IList<PersonModel> _persons;

        #endregion

        #region Свойства

        #region Привязки

        public IList<PersonModel> Persons
        {
            get => _persons;
            set
            {
                SetValue(ref _persons, value, nameof(Persons));
                ShowPersonCommand?.RaiseCanExecuteChanged();
            }
        }

        public PersonModel Person
        {
            get => _person;
            set
            {
                SetValue(ref _person, value, nameof(Person));
                ShowPersonCommand?.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Команды

        public Command ShowPersonCommand { get; }

        #endregion

        #endregion

        #region Конструкторы

        public PersonDirectoryViewModel()
        {
            _messageBoxService = ServiceLocator.Current.GetInstance<IMessageBoxService>();
            _dataSourceService = ServiceLocator.Current.GetInstance<IDataSourceService>();

            Persons = _dataSourceService.GetPersons();

            ShowPersonCommand = new Command(ExecuteShowPersonCommand, CanExecuteShowPersonCommand);
        }

        #endregion

        #region Методы

        private void ExecuteShowPersonCommand(object parameter)
        {
            _messageBoxService.ShowMessage($"{Person.Id.ToString()} {Person.Name} {Person.Age.ToString()}", "Просмотр персоны");
        }

        private bool CanExecuteShowPersonCommand(object parameter)
        {
            var canExecute = Person != null;

            return canExecute;
        }

        #endregion
    }
}
