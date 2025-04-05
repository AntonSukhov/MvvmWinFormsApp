using System;

namespace MvvmWinFormsApp.Common
{
    /// <summary>
    ///  Информация для автоматического создания и регистрации объекта в контейнер зависимостей.
    /// </summary>
    public sealed class RegistrationTypeInfo: RegistrationInfo
    {
        #region Свойства

        /// <summary>
        /// Получает или задаёт тип регистрируемого объекта.
        /// </summary>
        public Type ImplementationType { get; set; }

        #endregion
    }
}
