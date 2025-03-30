﻿using MvvmWinFormsApp.ViewModels;
using System;
using System.Windows.Forms;

namespace MvvmWinFormsApp.Views
{
    public partial class MainView : Form
    {
        #region Поля

        private readonly MainViewModel _mainViewModel;

        #endregion

        public MainView()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
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
