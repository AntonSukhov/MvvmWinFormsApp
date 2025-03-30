namespace MvvmWinFormsApp.Services
{
    public interface IMessageBoxService
    {
        void ShowMessage(string message, string title);
        bool ShowConfirmation(string message, string title);
    }
}
