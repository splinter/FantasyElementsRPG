using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyElementsRPG.Server.GameServer.RenderEngineModule
{
    [Module(ModuleName = Globals.ModuleNames.RenderEngineModule)]
    public class RenderEngineModule:IModule
    {
        private readonly IRegionManager _regionManager;



        public RenderEngineModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.Regions[Globals.RegionNames.MainRegion].Add(new Views.RenderEngineMainView());
        }
    }
}
