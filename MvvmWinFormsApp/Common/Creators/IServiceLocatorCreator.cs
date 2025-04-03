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
        /// 
        /// </summary>
        /// <param name="registrationTypeInfos"></param>
        /// <returns></returns>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationTypeInfo> registrationTypeInfos);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationTypeInfos"></param>
        /// <returns></returns>
        public ServiceLocatorImplBase Create(IEnumerable<RegistrationInstanceInfo> registrationInstanceInfos);

        #endregion
    }
}
