using MvvmWinFormsApp.Services;
using MvvmWinFormsApp.ViewModels;
using System;

namespace MvvmWinFormsApp.Views
{
    public partial class MainView : WindowService
    {
        private readonly MainViewModel _viewModel;

        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

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
            _viewModel.ShowPersonDirectoryCommand.Execute(this);
        }
    }
}
