using BackendManagement.CommonView.ViewModels;
using BackendManagement.CommonView.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackendManagement.CommonView
{
    public class CommonViewModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddAndEditUserView, AddAndEditUserViewModel>();
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<SystemRoleView, SystemRoleViewModel>();
            containerRegistry.RegisterForNavigation<SystemUserView, SystemUserViewModel>();
        }
    }
}
