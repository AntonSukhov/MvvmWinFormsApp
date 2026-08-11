using System;
using System.Windows.Input;

namespace MvvmWinFormsApp.Commands
{
    /// <summary>
    /// Базовая команда.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Инициализация экземпляра <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return _canExecute != null && _canExecute(parameter);
        }

        /// <summary>
        /// Принудительно уведомление подписанта о изменении состояния команды.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }
}
