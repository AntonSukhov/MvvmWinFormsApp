using MvvmWinFormsApp.Enums;

namespace MvvmWinFormsApp.Services
{
    public interface IWindowService
    {
        #region Методы

        /// <summary>
        /// Показывает окно.
        /// </summary>
        public void Show();

        /// <summary>
        /// Показывает окно.
        /// </summary>
        /// <param name="owner">Владелец окна.</param>
        public void Show(object owner);

        /// <summary>
        /// Показывает окно как модальное диалоговое окно.
        /// </summary>
        /// <returns>Результат действия окна.</returns>
        public WindowActionResult ShowDialog();

        /// <summary>
        /// Показывает окно как модальное диалоговое окно.
        /// </summary>
        /// <param name="owner">Владелец модального диалогового окна.</param>
        /// <returns>Результат действия окна.</returns>
        public WindowActionResult ShowDialog(object owner);

        #endregion
    }
}
