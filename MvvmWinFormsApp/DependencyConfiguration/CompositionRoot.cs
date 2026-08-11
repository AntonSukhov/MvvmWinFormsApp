using Autofac;
using MvvmWinFormsApp.Common;
using MvvmWinFormsApp.Services;

namespace MvvmWinFormsApp.DependencyConfiguration
{
    public static class CompositionRoot
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Сервисы: Singleton (живут всё время работы приложения)
            builder.RegisterType<MessageBoxService>()
                .Named<IMessageBoxService>(Constants.MessageBoxServiceName)
                .SingleInstance();

            builder.RegisterType<DataSourceService>()
                .Named<IDataSourceService>(Constants.DataSourceServiceName)
                .SingleInstance();

            return builder.Build();
        }
    }
}
