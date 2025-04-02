using CommonServiceLocator;

namespace MvvmWinFormsApp.Common.Creators
{
    /// <summary>
    /// Создатель локатора сервисов.
    /// </summary>
    public interface IServiceLocatorCreator
    {
        #region Методы

        /// <summary>
        /// Создаёт и предоставляет локатор сервисов.
        /// </summary>
        /// <returns>Локатор сервисов.</returns>
        public ServiceLocatorImplBase Create();

        #endregion
    }
}
