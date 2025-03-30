using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmWinFormsApp.Common
{
    /// <summary>
    /// Базовая реализация уведомления клиентов об изменении значения их свойства.
    /// </summary>
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        #region Поля

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Методы

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Установить значение поля объекта, связанного со свойством.
        /// </summary>
        /// <typeparam name="T">Тип данных поля.</typeparam>
        /// <param name="field">Поле</param>
        /// <param name="value">Устанавливаемое значение поля.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Признак установки значения поля.</returns>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
