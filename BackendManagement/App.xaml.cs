using Prism.DryIoc;
using Prism.Ioc;
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
            return Container.Resolve<Window>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }

}
