using BackendManagement.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BackendManagement
{
    public class MainWindowModel:BindableBase
    {
        private string? systemName;
        public string? SystemName
        {
            get => systemName;
            set => SetProperty(ref systemName, value);
        }


        public DelegateCommand<string>? NavigateCommand { get; private set; }
        public DelegateCommand? WindowMaximizeCommand { get; private set; }
        public DelegateCommand? WindowMinimizeCommand { get; private set; }
        public DelegateCommand? WindowCloseCommand { get; private set; }

        private readonly IRegionManager regionManager;
        public MainWindowModel(IRegionManager _regionManager) 
        {
            regionManager = _regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            WindowMaximizeCommand = new DelegateCommand(WindowMaximize);
            WindowMinimizeCommand=new DelegateCommand(WindowMinimize);
            WindowCloseCommand=new DelegateCommand(WindowClose);
        }
        private void Navigate(string nameSpace)
        {
            //if (obj == null || string.IsNullOrWhiteSpace(obj))
            //    return;
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(nameSpace);
        }
        private void WindowMaximize()
        {

        }
        private void WindowMinimize()
        {

        }
        private void WindowClose()
        {

        }
    }
}
