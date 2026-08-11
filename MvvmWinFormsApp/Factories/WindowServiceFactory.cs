using Autofac;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Services;
using MvvmWinFormsApp.ViewModels;
using MvvmWinFormsApp.Views;
using System;

namespace MvvmWinFormsApp.Factories
{
    public class WindowServiceFactory : IWindowServiceFactory
    {
        private readonly ILifetimeScope _scope;

        public WindowServiceFactory(ILifetimeScope scope)
        {
            _scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }

        public IWindowService CreatePersonDirectoryWindow()
        {
            var messageBoxService = _scope.ResolveNamed<IMessageBoxService>(Constants.MessageBoxServiceName);
            var dataSourceService = _scope.ResolveNamed<IDataSourceService>(Constants.DataSourceServiceName);

            var personDirectoryViewModel = new PersonDirectoryViewModel(messageBoxService, dataSourceService);
            var personDirectoryView = new PersonDirectoryView(personDirectoryViewModel);

            return personDirectoryView;
        }
    }
}
