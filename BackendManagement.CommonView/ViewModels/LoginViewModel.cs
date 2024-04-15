using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendManagement.CommonView.ViewModels
{
    internal class LoginViewModel : IDialogAware
    {
        public string Title {  get; set; }=string.Empty;


        public DelegateCommand? CancelCommand { get; private set; }
        public DelegateCommand? LoginCommand { get; private set; }
        public DelegateCommand? RegisterCommand { get; private set; }
        public LoginViewModel()
        {
            CancelCommand = new DelegateCommand(cancel);
            LoginCommand = new DelegateCommand(login);
            RegisterCommand = new DelegateCommand(register);
        }
        private void cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        }
        private void login()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }
        private void register()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Ignore));
        }

        public event Action<IDialogResult>? RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
