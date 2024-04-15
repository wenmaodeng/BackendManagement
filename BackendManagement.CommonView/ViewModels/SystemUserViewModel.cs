using BackendManagement.CommonView.Views;
using BackendManagement.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendManagement.CommonView.ViewModels
{
    public class SystemUserViewModel: BindableBase
    {
        private SystemUser? _systemUser;
        public SystemUser? systemUser
        {
            get => _systemUser;
            set => SetProperty(ref _systemUser, value);
        }
        public DelegateCommand<SystemUser>? AddUserCommand { get; private set; }
        public DelegateCommand<SystemUser>? EditUserCommand { get; private set; }
        private readonly IDialogService dialogService;
        public SystemUserViewModel(IDialogService _dialogService) 
        {
            dialogService = _dialogService;
            AddUserCommand = new DelegateCommand<SystemUser>(AddAndEditUser);
            EditUserCommand = new DelegateCommand<SystemUser>(AddAndEditUser);
        }
        private void AddAndEditUser(SystemUser? user = null)
        {
            dialogService.ShowDialog(nameof(AddAndEditUserView), callback =>
            {

            });
        }
    }
}
