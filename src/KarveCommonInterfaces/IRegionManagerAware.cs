using Prism.Regions;

namespace KarveCommonInterfaces
{
        // IRegionManagerAware   
        public interface IRegionManagerAware
        {
            IRegionManager RegionManager { get; set; }
        }
    
}
