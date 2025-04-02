namespace MvvmWinFormsApp.Enums
{
    /// <summary>
    /// Результат действия окна.
    /// </summary>
    public enum WindowActionResult
    {
        /// <summary>
        /// Окно закрывается без результата.
        /// </summary>
        None = 0,

        /// <summary>
        /// Возвращаемое значение окна является OK.
        /// </summary>
        OK = 1,

        /// <summary>
        /// Возвращаемое значение окна является Cancel.
        /// </summary>
        Cancel = 2,

        /// <summary>
        /// Возвращаемое значение окна является Yes.
        /// </summary>
        Yes = 6,

        /// <summary>
        /// Возвращаемое значение окна является No.
        /// </summary>
        No = 7
    }
}
