using System.Windows.Forms;

namespace MvvmWinFormsApp.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool ShowConfirmation(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }
    }
}
