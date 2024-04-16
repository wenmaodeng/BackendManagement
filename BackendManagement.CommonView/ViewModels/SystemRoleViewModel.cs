using Prism.Common;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BackendManagement.CommonView.ViewModels
{
    public class SystemRoleViewModel: BindableBase,IConfirmNavigationRequest
    {
        private IFreeSql? freeSql = null;
        public SystemRoleViewModel(IFreeSql? _freeSql) 
        {
            freeSql = _freeSql;
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            //是否离开当前页面
            bool result = true;
            if (MessageBox.Show("是否离开当前页面？", "系统提示", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                result = false;
            }
            continuationCallback(result);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}
