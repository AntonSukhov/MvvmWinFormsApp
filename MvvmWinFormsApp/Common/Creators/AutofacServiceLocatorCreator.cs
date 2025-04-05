using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvvmWinFormsApp.Common.Creators
{
    /// <summary>
    /// Создатель локатора сервисов, работающего с Autofac.
    /// </summary>
    public class AutofacServiceLocatorCreator : IServiceLocatorCreator
    {
        #region Методы

        /// <inheritdoc/>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationInstanceInfo> registrationInstanceInfos)
        {
            return CreateServiceLocator(containerBuilder => RegisterDependencies(containerBuilder, registrationInstanceInfos, RegisterInstance));
        }

        /// <inheritdoc/>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationTypeInfo> registrationTypeInfos)
        {
            return CreateServiceLocator(containerBuilder => RegisterDependencies(containerBuilder, registrationTypeInfos, RegisterType));
        }

        #region Закрытые методы

        /// <summary>
        /// Создаёт локатор сервисов.
        /// </summary>
        /// <param name="registerDependenciesAction">Действие, регистрирующее зависимости.</param>
        /// <returns>Локатор сервисов.</returns>
        private ServiceLocatorImplBase CreateServiceLocator(Action<ContainerBuilder> registerDependenciesAction)
        {
            var builder = new ContainerBuilder();

            registerDependenciesAction(builder);

            return new AutofacServiceLocator(builder.Build());
        }

        /// <summary>
        /// Регистрирует зависимости.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="containerBuilder">Создатель контейнера.</param>
        /// <param name="registrationInfos">Коллекция с информацией о регистрируемых зависимостях.</param>
        /// <param name="registerAction">Действие, регистрирующее зависимость.</param>
        private void RegisterDependencies<T>(ContainerBuilder containerBuilder, IEnumerable<T> registrationInfos, Action<ContainerBuilder, T> registerAction)
        {
            if (registrationInfos?.Any() == true)
            {
                foreach (var registrationInfo in registrationInfos)
                {
                    registerAction(containerBuilder, registrationInfo);
                }
            }
        }

        /// <summary>
        /// Регистрирует зависимость, которая автоматически создаётся по его типу.
        /// </summary>
        /// <param name="containerBuilder">Создатель контейнера.</param>
        /// <param name="registrationTypeInfo"> Информация для автоматического создания и регистрации объекта в контейнер зависимостей.</param>
        private void RegisterType(ContainerBuilder containerBuilder, RegistrationTypeInfo registrationTypeInfo)
        {
            if (string.IsNullOrEmpty(registrationTypeInfo.KeyName))
            {
                if (registrationTypeInfo.IsSingleton)
                {
                    containerBuilder.RegisterType(registrationTypeInfo.ImplementationType)
                                    .As(registrationTypeInfo.InterfaceType)
                                    .SingleInstance();
                }
                else
                {
                    containerBuilder.RegisterType(registrationTypeInfo.ImplementationType)
                                    .As(registrationTypeInfo.InterfaceType);
                }
            }
            else
            {
                if (registrationTypeInfo.IsSingleton)
                {
                    containerBuilder.RegisterType(registrationTypeInfo.ImplementationType)
                                    .Named(registrationTypeInfo.KeyName, registrationTypeInfo.InterfaceType)
                                    .SingleInstance();
                }
                else
                {

                    containerBuilder.RegisterType(registrationTypeInfo.ImplementationType)
                                    .Named(registrationTypeInfo.KeyName, registrationTypeInfo.InterfaceType);
                }
            }
        }

        /// <summary>
        ///  Регистрирует ранее созданную зависимость.
        /// </summary>
        /// <param name="containerBuilder">Создатель контейнера.</param>
        /// <param name="registrationInstanceInfo">Информация для регистрации ранее созданного (вне контейнера) объекта в контейнер зависимостей</param>
        private void RegisterInstance(ContainerBuilder containerBuilder, RegistrationInstanceInfo registrationInstanceInfo)
        {
            if (string.IsNullOrEmpty(registrationInstanceInfo.KeyName))
            {
                if (registrationInstanceInfo.IsSingleton)
                {
                    containerBuilder.RegisterInstance(registrationInstanceInfo.ImplementationInstance)
                                .As(registrationInstanceInfo.InterfaceType)
                                .SingleInstance();
                }
                else
                {
                    containerBuilder.RegisterInstance(registrationInstanceInfo.ImplementationInstance)
                                    .As(registrationInstanceInfo.InterfaceType);
                }
            }
            else
            {
                if (registrationInstanceInfo.IsSingleton)
                {
                    containerBuilder.RegisterInstance(registrationInstanceInfo.ImplementationInstance)
                                .Named(registrationInstanceInfo.KeyName, registrationInstanceInfo.InterfaceType)
                                .SingleInstance();
                }
                else
                {
                    containerBuilder.RegisterInstance(registrationInstanceInfo.ImplementationInstance)
                                .Named(registrationInstanceInfo.KeyName, registrationInstanceInfo.InterfaceType);
                }
            }
        }

        #endregion

        #endregion
    }
}
