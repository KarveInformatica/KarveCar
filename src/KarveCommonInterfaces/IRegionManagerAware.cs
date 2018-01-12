using Prism.Regions;

namespace KarveCommonInterfaces
{
    

        public interface IRegionManagerAware
        {
            IRegionManager RegionManager { get; set; }
        }
    
}
