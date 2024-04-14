using BackendManagement.Extensions;
using BackendManagement.MessageEvent;
using BackendManagement.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace BackendManagement
{
    public class MainWindowModel:BindableBase, IConfigWindow
    {
        private string? systemName;
        public string? SystemName
        {
            get => systemName;
            set => SetProperty(ref systemName, value);
        }
        private bool isLeftDrawerOpen;

        public bool IsLeftDrawerOpen
        {
            get => isLeftDrawerOpen;
            set => SetProperty(ref isLeftDrawerOpen, value);
        }



        public DelegateCommand<string>? NavigateCommand { get; private set; }
        public DelegateCommand? WindowMaximizeCommand { get; private set; }
        public DelegateCommand? WindowMinimizeCommand { get; private set; }
        public DelegateCommand? WindowCloseCommand { get; private set; }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator aggregator;
        public MainWindowModel(IRegionManager _regionManager, IEventAggregator _aggregator) 
        {
            regionManager = _regionManager;
            aggregator = _aggregator;
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
            IsLeftDrawerOpen = false;
        }
        private void WindowMaximize()
        {
            aggregator.GetEvent<WindowManagerEvent>().Publish("WindowMaximize");
        }
        private void WindowMinimize()
        {
            aggregator.GetEvent<WindowManagerEvent>().Publish("WindowMinimize");
        }
        private void WindowClose()
        {
            aggregator.GetEvent<WindowManagerEvent>().Publish("WindowClose");
        }
        public void InitWindow()
        {
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("TestView");
        }
    }
}
