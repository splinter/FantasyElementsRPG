using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.Unity;

namespace FantasyElementsRPG.Shell
{
    public class FantasyElementsRPG_Bootstrapper : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<FantasyElementsRPG_Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.RootVisual = (UIElement)this.Shell;
        }
    }
}
