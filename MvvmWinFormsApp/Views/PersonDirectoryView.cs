using MvvmWinFormsApp.Models;
using MvvmWinFormsApp.ViewModels;
using System.Windows.Forms;

namespace MvvmWinFormsApp.Views
{
    public partial class PersonDirectoryView : Form
    {
        #region Поля

        private readonly PersonDirectoryViewModel _personDirectoryViewModel;

        #endregion

        #region Конструкторы

        public PersonDirectoryView()
        {
            _personDirectoryViewModel = new PersonDirectoryViewModel();

            InitializeComponent();
            InitializeBindings();
        }

        #endregion

        #region Методы

        private void InitializeBindings()
        {
            bsPersons.DataSource = _personDirectoryViewModel.Persons;
            dgvPersons.DataSource = bsPersons;
            bnPersons.BindingSource = bsPersons;

            _personDirectoryViewModel.ShowPersonCommand.CanExecuteChanged += ShowPersonCommand_CanExecuteChanged;
        }

        #region Обработчики событий


        private void ShowPersonCommand_CanExecuteChanged(object sender, System.EventArgs e)
        {
            var canExecute = _personDirectoryViewModel.ShowPersonCommand.CanExecute(null);
            tsbShowPerson.Enabled = canExecute;
        }

        private void DgvPersons_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dgvPersons.SelectedRows.Count > 0)
            {
                var selectedUser = dgvPersons.SelectedRows[0].DataBoundItem as PersonModel;

                _personDirectoryViewModel.Person = selectedUser;

            }
        }

        private void BtnShowPerson_Click(object sender, System.EventArgs e)
        {
            ShowPerson();
        }

        private void TsbShowPerson_Click(object sender, System.EventArgs e)
        {
            ShowPerson();
        }

        private void ShowPerson()
        {
            if (_personDirectoryViewModel.ShowPersonCommand.CanExecute(null))
            {
                _personDirectoryViewModel.ShowPersonCommand.Execute(null);
            }
        }

        #endregion

        #endregion

    }
}