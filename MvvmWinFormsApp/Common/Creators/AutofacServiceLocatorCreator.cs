using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MvvmWinFormsApp.Services;

namespace MvvmWinFormsApp.Common.Creators
{
    /// <summary>
    /// Создатель локатора сервисов, работающего с IoC Autofac.
    /// </summary>
    public class AutofacServiceLocatorCreator : IServiceLocatorCreator
    {
        #region Методы

        /// <inheritdoc/>
        public ServiceLocatorImplBase Create()
        {
            var builder = new ContainerBuilder();

            RegisterDependencies(builder);

            var container = builder.Build();

            var serviceLocatorImpl = new AutofacServiceLocator(container);

            return serviceLocatorImpl;
        }

        /// <summary>
        /// Регистрация зависимостей в контейнере.
        /// </summary>
        /// <param name="builder">Создатель контейнера.</param>
        private void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<MessageBoxService>().As<IMessageBoxService>();
            builder.RegisterType<DataSourceService>().As<IDataSourceService>();
        }

        #endregion
    }
}
