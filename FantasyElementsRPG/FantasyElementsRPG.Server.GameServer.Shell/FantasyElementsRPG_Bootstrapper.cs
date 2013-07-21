using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;

namespace FantasyElementsRPG.Server.GameServer.Shell
{
    class FantasyElementsRPG_Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<FantasyElementsRPG_Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();

            IModuleManager moduleManager = Container.Resolve<IModuleManager>();

            moduleManager.LoadModule(Globals.ModuleNames.RenderEngineModule);
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(RenderEngineModule.RenderEngineModule),InitializationMode.OnDemand);
        }
    }
}
