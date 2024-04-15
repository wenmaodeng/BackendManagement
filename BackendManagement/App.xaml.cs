using BackendManagement.BusinessView;
using BackendManagement.CommonView;
using BackendManagement.Services;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Services.Dialogs;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BackendManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            IFreeSql freeSql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=BackendManagement.db")
                .UseAutoSyncStructure(true)
                .Build();
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowModel>();
            containerRegistry.RegisterInstance(freeSql);
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback =>
            {
                switch (callback.Result)
                {
                    case ButtonResult.OK:
                        IConfigWindow? service = App.Current.MainWindow.DataContext as IConfigWindow;
                        if (service != null)
                        {
                            service.InitWindow();
                        }
                        base.OnInitialized();
                        break;
                    case ButtonResult.Ignore:
                        //跳转注册界面
                        break;
                    case ButtonResult.Cancel:
                    default:
                        Environment.Exit(0);
                        return;
                }
            });
        }

        /// <summary>
        /// 从目录加载Module
        /// </summary>
        /// <returns></returns>
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\\Modules" };
        //}
        /// <summary>
        /// 代码加载Module
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<BusinessViewModule>();
            moduleCatalog.AddModule<CommonViewModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
