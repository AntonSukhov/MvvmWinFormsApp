using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using MvvmWinFormsApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace MvvmWinFormsApp.Common.Creators
{
    /// <summary>
    /// Создатель локатора сервисов, работающего с IoC Autofac.
    /// </summary>
    public class AutofacServiceLocatorCreator : IServiceLocatorCreator
    {
        #region Методы

        /// <inheritdoc/>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationInstanceInfo> registrationInstanceInfos)
        {
            var builder = new ContainerBuilder();

            if (registrationInstanceInfos?.Count() > 0)
            {
                RegisterDependencies(builder, registrationInstanceInfos);
            }

            var container = builder.Build();

            var serviceLocatorImpl = new AutofacServiceLocator(container);

            return serviceLocatorImpl;
        }

        /// <inheritdoc/>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationTypeInfo> registrationTypeInfos)
        {
            var builder = new ContainerBuilder();

            if (registrationTypeInfos?.Count() > 0)
            {
                RegisterDependencies(builder, registrationTypeInfos);
            }

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
            builder.RegisterType(typeof(MessageBoxService))
                   .Named(ConstantsService.MessageBoxServiceName, typeof(IMessageBoxService));
            builder.RegisterType(typeof(DataSourceService))
                   .Named(ConstantsService.DataSourceServiceName, typeof(IDataSourceService));
        }

        /// <summary>
        /// Регистрация зависимостей в контейнере.
        /// </summary>
        /// <param name="builder">Создатель контейнера.</param>
        /// <param name="registrationTypeInfos"></param>
        private void RegisterDependencies(ContainerBuilder builder, IEnumerable<RegistrationTypeInfo> registrationTypeInfos)
        {
            foreach (var registrationInfo in registrationTypeInfos)
            {
                var keyName = registrationInfo.KeyName;

                if (string.IsNullOrEmpty(keyName))
                {
                    builder.RegisterType(registrationInfo.ImplementationType)
                           .As(registrationInfo.InterfaceType);
                }
                else
                {

                    builder.RegisterType(registrationInfo.ImplementationType)
                           .Named(registrationInfo.KeyName, registrationInfo.InterfaceType);
                }
            }
        }

        /// <summary>
        /// Регистрация зависимостей в контейнере.
        /// </summary>
        /// <param name="builder">Создатель контейнера.</param>
        /// <param name="registrationInstanceInfos"></param>
        private void RegisterDependencies(ContainerBuilder builder, IEnumerable<RegistrationInstanceInfo> registrationInstanceInfos)
        {
            foreach (var registrationInfo in registrationInstanceInfos)
            {
                var keyName = registrationInfo.KeyName;

                if (string.IsNullOrEmpty(keyName))
                {
                    builder.RegisterInstance(registrationInfo.ImplementationInstance)
                           .As(registrationInfo.InterfaceType);
                }
                else
                {

                    builder.RegisterInstance(registrationInfo.ImplementationInstance)
                           .Named(registrationInfo.KeyName, registrationInfo.InterfaceType);
                }
            }
        }

        #endregion
    }
}
