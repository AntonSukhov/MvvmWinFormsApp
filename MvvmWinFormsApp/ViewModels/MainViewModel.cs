using MvvmWinFormsApp.Commands;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Factories;
using MvvmWinFormsApp.Services;
using System;

namespace MvvmWinFormsApp.ViewModels
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private readonly IWindowServiceFactory _windowFactory;

        public RelayCommand ShowPersonDirectoryCommand { get; }

        public MainViewModel(IWindowServiceFactory windowFactory)
        {
            _windowFactory = windowFactory ?? throw new ArgumentNullException(nameof(windowFactory));

            ShowPersonDirectoryCommand = new RelayCommand(ExecuteShowPersonDirectoryCommand);
        }

        private void ExecuteShowPersonDirectoryCommand(object parameter)
        {
            var owner = parameter as IWindowService;

            var personDirectoryView = _windowFactory.CreatePersonDirectoryWindow();

            personDirectoryView.SetMdiParent(owner);
            personDirectoryView.Show();
        }
    }
}
