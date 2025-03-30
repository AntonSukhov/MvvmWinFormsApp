using System;
using System.Windows.Input;

namespace MvvmWinFormsApp.Commands
{
    /// <summary>
    /// Базовая команда.
    /// </summary>
    public class Command : ICommand
    {
        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public Command(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #region Методы

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            var canExecute = _canExecute?.Invoke(parameter) ?? true;

            return canExecute;
        }

        /// <summary>
        /// Принудительно уведомление подписанта о изменении состояния команды.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
