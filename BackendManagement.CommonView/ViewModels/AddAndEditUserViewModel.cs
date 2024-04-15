using BackendManagement.Model;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendManagement.CommonView.ViewModels
{
    public class AddAndEditUserViewModel :BindableBase, IDialogAware
    {
        private IFreeSql? freeSql = null;
        private SystemUser? _systemUser;
        private string? title;
        public string? Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        
        
        public SystemUser? systemUser
        {
            get => _systemUser;
            set => SetProperty(ref _systemUser, value);
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
            if (freeSql == null && parameters.ContainsKey(typeof(IFreeSql).Name))
            {
                freeSql = parameters.GetValue<IFreeSql>(typeof(IFreeSql).Name);
            }
            if (freeSql != null && parameters.ContainsKey(nameof(SystemUser)))
            {
                systemUser = parameters.GetValue<SystemUser>(nameof(SystemUser));
                if(systemUser != null)
                {
                    Title = "编辑用户";
                }
                else
                {
                    systemUser=new SystemUser();
                    Title = "添加用户";
                }
            }
        }
    }
}
