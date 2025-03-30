using CommonServiceLocator;
using MvvmWinFormsApp.Creators;
using MvvmWinFormsApp.Views;
using System;
using System.Windows.Forms;

namespace MvvmWinFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceLocatorCreator = new AutofacServiceLocatorCreator();
            var serviceLocatorImpl = serviceLocatorCreator.Create();

            ServiceLocator.SetLocatorProvider(() => serviceLocatorImpl);

            Application.Run(new MainView());
        }
    }
}
