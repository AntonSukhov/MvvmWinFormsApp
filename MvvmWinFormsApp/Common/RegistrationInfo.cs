using System;

namespace MvvmWinFormsApp.Common
{
    /// <summary>
    /// Базовая информация для регистрации объекта в контейнер зависимостей.
    /// </summary>
    public class RegistrationInfo
    {
        #region Свойства

        /// <summary>
        /// Получает или задаёт тип интерфейса для регистрируемого объекта.
        /// </summary>
        public Type InterfaceType { get; set; }

        /// <summary>
        /// Получает или задаёт название ключа объекта для его уникальной идентификации в контейнере зависимостей.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Получает или задаёт значение, указывающее, будет ли возвращаться один и тот же объект при каждом его запросе.
        /// </summary>
        public bool IsSingleton { get; set; }

        #endregion
    }
}
