using MvvmWinFormsApp.Enums;
using System.Windows.Forms;

namespace MvvmWinFormsApp.Services
{
    /// <summary>
    /// Реализация сервиса работы с окном.
    /// </summary>
    public class WindowService : Form, IWindowService
    {
        ///<inheritdoc/>   
        public void SetMdiParent(IWindowService parent)
        {
            if (parent is Form formOwner)
            {
                MdiParent = formOwner;
            }
        }

        ///<inheritdoc/>
        public new void Show() => base.Show();

        ///<inheritdoc/>
        public void Show(IWindowService owner) => Show(owner as IWin32Window);

        ///<inheritdoc/>
        public new WindowActionResult ShowDialog() => (WindowActionResult)base.ShowDialog();

        ///<inheritdoc/>
        public WindowActionResult ShowDialog(IWindowService owner) => (WindowActionResult)ShowDialog(owner as IWin32Window);

    }
}
