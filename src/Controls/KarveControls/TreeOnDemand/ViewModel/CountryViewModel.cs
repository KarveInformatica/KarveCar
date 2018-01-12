using System.Collections.ObjectModel;
using System.Linq;
using BusinessLib;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    /// <summary>
    /// The ViewModel for the LoadOnDemand demo.  This simply
    /// exposes a read-only collection of regions.
    /// </summary>
    public class CountryViewModel
    {
        readonly ReadOnlyCollection<RegionViewModel> _regions;

        public CountryViewModel(Region[] regions)
        {
            _regions = new ReadOnlyCollection<RegionViewModel>(
                (from region in regions
                 select new RegionViewModel(region))
                .ToList());
        }

        public ReadOnlyCollection<RegionViewModel> Regions
        {
            get { return _regions; }
        }
    }
}