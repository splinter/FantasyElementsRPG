using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
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

namespace FantasyElementsRPG.Client.Core.FatalExceptionUserControl
{
    public class FatalExceptionUserControlModule : IModule
    {
        private readonly IRegionManager regionManager;

        public FatalExceptionUserControlModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("ExceptionRegion", typeof(Views.FatalExceptionControl));
        }
    }
}
