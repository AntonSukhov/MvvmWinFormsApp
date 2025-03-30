using MvvmWinFormsApp.Commands;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Services;
using MvvmWinFormsApp.Views;
using System;
using System.Windows.Forms;

namespace MvvmWinFormsApp.ViewModels
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        #region Поля

        private readonly IMessageBoxService _messageBoxService;

        #endregion

        #region Свойства

        #region Команды

        public Command ShowPersonDirectoryCommand { get; }

        #endregion

        #endregion

        #region Конструкторы

        public MainViewModel(IMessageBoxService messageBoxService)
        {

            _messageBoxService = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));        //TODO: избавиться от передачи сервисов через конструктор и
                                                                                                                         //использовать глобальную коллекцию сервисов для получения сервиса.

            ShowPersonDirectoryCommand = new Command(ExecuteShowPersonDirectoryCommand);
        }

        #endregion

        #region Методы

        private void ExecuteShowPersonDirectoryCommand(object parameter)
        {
            var owner = parameter as Form;                                                                             //TODO:  избавиться от прямой зависимости от класса Form.
            var personDirectoryView = new PersonDirectoryView                                                          //TODO: избавиться от прямой зависимости от класса PersonDirectoryView и
                                                                                                                       //использовать сервис, который настраивается и регистрируется в коллеции сервисов
                                                                                                                       //на уроенв MainView.
            {
                MdiParent = owner
            };

            personDirectoryView.Show();
        }

        #endregion
    }
}
