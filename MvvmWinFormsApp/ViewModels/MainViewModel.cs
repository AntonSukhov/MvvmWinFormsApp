using CommonServiceLocator;
using MvvmWinFormsApp.Commands;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Services;
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

        public MainViewModel()
        {
            _messageBoxService = ServiceLocator.Current.GetInstance<IMessageBoxService>(ConstantsService.MessageBoxServiceName);
            ShowPersonDirectoryCommand = new Command(ExecuteShowPersonDirectoryCommand);
        }

        #endregion

        #region Методы

        private void ExecuteShowPersonDirectoryCommand(object parameter)
        {
            var owner = parameter as Form;                                                                                //TODO:  избавиться от прямой зависимости от класса Form.
            var personDirectoryView = ServiceLocator.Current.GetInstance<Form>(ConstantsService.PersonDirectoryViewName);
            personDirectoryView.MdiParent = owner;

            personDirectoryView.Show();
        }

        #endregion
    }
}
