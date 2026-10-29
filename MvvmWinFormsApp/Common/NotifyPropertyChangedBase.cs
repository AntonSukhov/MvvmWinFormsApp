using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmWinFormsApp.Common
{
    /// <summary>
    /// Базовая реализация уведомления клиентов об изменении значения их свойства.
    /// </summary>
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Установить значение свойства.
        /// </summary>
        /// <typeparam name="T">Тип данных свойства.</typeparam>
        /// <param name="field">Поле.</param>
        /// <param name="value">Устанавливаемое значение поля.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Признак установки значения свойства.</returns>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}