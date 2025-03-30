using MvvmWinFormsApp.Services;
using MvvmWinFormsApp.ViewModels;
using System;
using System.Windows.Forms;

namespace MvvmWinFormsApp.Views
{
    public partial class MainView : Form
    {
        #region Поля

        private readonly MainViewModel _mainViewModel = new MainViewModel(new MessageBoxService());  //TODO: создать MessageBoxService и зарегистрировать сервис в глобальную (по отношению к проекту)
                                                                                                     //коллекцию сервисов.

        #endregion

        public MainView()
        {
            InitializeComponent();
        }

        #region Обработчики событий

        private void TsmiPersonDirectory_Click(object sender, EventArgs e)
        {
            ShowPersonDirectory();
        }

        private void TsbPersonDirectory_Click(object sender, EventArgs e)
        {
            ShowPersonDirectory();
        }

        /// <summary>
        /// Показывает справочник персон.
        /// </summary>
        private void ShowPersonDirectory()
        {
            _mainViewModel.ShowPersonDirectoryCommand.Execute(this);
        }

        #endregion

    }
}
