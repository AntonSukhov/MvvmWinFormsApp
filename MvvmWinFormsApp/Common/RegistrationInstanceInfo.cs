namespace MvvmWinFormsApp.Common
{
    /// <summary>
    /// Информация для регистрации ранее созданного (вне контейнера) объекта в контейнер зависимостей.
    /// </summary>
    public sealed class RegistrationInstanceInfo : RegistrationInfo
    {
        #region Свойства

        /// <summary>
        /// Получает или задаёт регистрируемый объект.
        /// </summary>
        public object ImplementationInstance { get; set; }

        #endregion
    }
}
