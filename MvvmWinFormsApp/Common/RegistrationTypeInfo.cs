using System;

namespace MvvmWinFormsApp.Common
{
    /// <summary>
    ///  
    /// </summary>
    public class RegistrationTypeInfo
    {
        #region Свойства

        /// <summary>
        /// Получает или задаёт тип регистрируемого класса в DI-контейнере.
        /// </summary>
        public Type ImplementationType { get; set; }

        /// <summary>
        /// Получает или задаёт тип интерфейса регистрируемого класса в DI-контейнере.
        /// </summary>
        public Type InterfaceType { get; set; }

        /// <summary>
        /// Получает или задаёт название ключа для идентификации класса при его регистрации и получении в DI-контейнере.
        /// </summary>
        public string KeyName { get; set; } 

        #endregion
    }
}
