using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MvvmWinFormsApp.Common
{
    /// <summary>
    /// Базовый класс с хранением свойств в словаре.
    /// </summary>
    /// <remarks>
    /// Позволяет описывать свойства в производном классе без приватных backing-полей:
    /// <c>public int Id { get => GetValue<int>(nameof(Id)); set => SetValue(value, nameof(Id)); }</c>
    /// </remarks>
    public abstract class DynamicNotifyPropertyChangedBase : NotifyPropertyChangedBase
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        /// <summary>
        /// Установить значение свойства, хранимого в словаре.
        /// </summary>
        /// <typeparam name="T">Тип данных свойства.</typeparam>
        /// <param name="value">Устанавливаемое значение.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Признак установки значения свойства.</returns>
        protected bool SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            _properties.TryGetValue(propertyName, out var oldValue);

            if (EqualityComparer<object>.Default.Equals(oldValue, value))
            {
                return false;
            }

            _properties[propertyName] = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Прочитать значение свойства, хранимого в словаре.
        /// </summary>
        /// <typeparam name="T">Тип данных свойства.</typeparam>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Значение свойства; для незанесённого — <c>default</c>.</returns>
        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            return _properties.TryGetValue(propertyName, out var value) ? (T)value : default;
        }
    }
}