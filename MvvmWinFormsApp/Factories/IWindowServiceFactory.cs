using MvvmWinFormsApp.Services;

namespace MvvmWinFormsApp.Factories
{
    public interface IWindowServiceFactory
    {
        IWindowService CreatePersonDirectoryWindow();
    }
}
