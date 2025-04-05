using CommonServiceLocator;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Common.Creators;
using MvvmWinFormsApp.Services;
using MvvmWinFormsApp.Views;
using System;
using System.Windows.Forms;

namespace MvvmWinFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalRegisterDependencies();

            Application.Run(new MainView());
        }

        /// <summary>
        /// Глобальная регистрация зависимостей.
        /// </summary>
        static void GlobalRegisterDependencies()
        {
            var registrationInfos = new[]
           {
                new RegistrationTypeInfo
                {
                    ImplementationType = typeof(MessageBoxService),
                    InterfaceType = typeof(IMessageBoxService),
                    KeyName = ConstantsService.MessageBoxServiceName,
                    IsSingleton = true,
                },
                new RegistrationTypeInfo
                {
                    ImplementationType = typeof(DataSourceService),
                    InterfaceType = typeof(IDataSourceService),
                    KeyName = ConstantsService.DataSourceServiceName,
                    IsSingleton= true
                },
                new RegistrationTypeInfo
                {
                    ImplementationType= typeof(PersonDirectoryView),
                    InterfaceType = typeof(IWindowService),
                    KeyName = ConstantsService.PersonDirectoryViewName
                }
            };

            var serviceLocatorCreator = new AutofacServiceLocatorCreator();
            var serviceLocatorImpl = serviceLocatorCreator.Create(registrationInfos);

            ServiceLocator.SetLocatorProvider(() => serviceLocatorImpl);
        }
    }
}
