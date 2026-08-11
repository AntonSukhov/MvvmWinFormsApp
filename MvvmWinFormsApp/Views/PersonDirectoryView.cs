using MvvmWinFormsApp.Models;
using MvvmWinFormsApp.Services;
using MvvmWinFormsApp.ViewModels;
using System;

namespace MvvmWinFormsApp.Views
{
    public partial class PersonDirectoryView : WindowService
    {
        private readonly PersonDirectoryViewModel _personDirectoryViewModel;

        public PersonDirectoryView(PersonDirectoryViewModel viewModel)
        {
            InitializeComponent();

            _personDirectoryViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

            InitializeBindings();
        }

        private void InitializeBindings()
        {
            bsPersons.DataSource = _personDirectoryViewModel.Persons;
            dgvPersons.DataSource = bsPersons;
            bnPersons.BindingSource = bsPersons;

            _personDirectoryViewModel.ShowPersonCommand.CanExecuteChanged += ShowPersonCommand_CanExecuteChanged;
        }

        private void ShowPersonCommand_CanExecuteChanged(object sender, System.EventArgs e)
        {
            tsbShowPerson.Enabled = _personDirectoryViewModel.ShowPersonCommand.CanExecute(null);
        }

        private void DgvPersons_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dgvPersons.SelectedRows.Count > 0)
            {
                var selectedUser = dgvPersons.SelectedRows[0].DataBoundItem as PersonModel;

                _personDirectoryViewModel.Person = selectedUser;

            }
        }

        private void BtnShowPerson_Click(object sender, System.EventArgs e) => ShowPerson();
        private void TsbShowPerson_Click(object sender, System.EventArgs e) => ShowPerson();

        private void ShowPerson()
        {
            if (_personDirectoryViewModel.ShowPersonCommand.CanExecute(null))
            {
                _personDirectoryViewModel.ShowPersonCommand.Execute(null);
            }
        }
    }
}