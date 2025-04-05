using CommonServiceLocator;
using System.Collections.Generic;

namespace MvvmWinFormsApp.Common.Creators
{
    /// <summary>
    /// Создатель локатора сервисов.
    /// </summary>
    public interface IServiceLocatorCreator
    {
        #region Методы

        /// <summary>
        /// Создаёт локатор сервисов.
        /// </summary>
        /// <param name="registrationTypeInfos">Информация для автоматического создания и регистрации объектов в контейнере зависимостей.</param>
        /// <returns>Локатор сервисов.</returns>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationTypeInfo> registrationTypeInfos);

        /// <summary>
        /// Создаёт локатор сервисов.
        /// </summary>
        /// <param name="registrationTypeInfos">Информация для регистрации объектов в контейнере зависимостей.</param>
        /// <returns>Локатор сервисов.</returns>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationInstanceInfo> registrationInstanceInfos);

        #endregion
    }
}
