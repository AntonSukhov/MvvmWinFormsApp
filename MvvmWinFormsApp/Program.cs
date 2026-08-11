using MvvmWinFormsApp.DependencyConfiguration;
using MvvmWinFormsApp.Factories;
using MvvmWinFormsApp.ViewModels;
using MvvmWinFormsApp.Views;
using System;
using System.Windows.Forms;

namespace MvvmWinFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Получаем контейнер из настроек
            var container = CompositionRoot.BuildContainer();

            // Создаём scope — он живёт всё время работы приложения
            using (var scope = container.BeginLifetimeScope())
            {
                // Фабрика знает про Autofac, но View об этом не догадывается
                var windowFactory = new WindowServiceFactory(scope);

                var mainViewModel = new MainViewModel(windowFactory);

                var mainView = new MainView(mainViewModel);

                // Запускаем приложение
                Application.Run(mainView);
            }
        }
    }
}
