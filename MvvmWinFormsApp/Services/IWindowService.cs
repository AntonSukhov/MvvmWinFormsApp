using MvvmWinFormsApp.Enums;

namespace MvvmWinFormsApp.Services
{
    /// <summary>
    /// Сервис работы с окном.
    /// </summary>
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
        public void Show(IWindowService owner);

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
        public WindowActionResult ShowDialog(IWindowService owner);

        /// <summary>
        /// Задает для окна родительское MDI-окно.        
        /// </summary>
        /// <param name="parent">Родительское MDI-окно.</param>
        public void SetMdiParent(IWindowService parent);

        #endregion
    }
}
