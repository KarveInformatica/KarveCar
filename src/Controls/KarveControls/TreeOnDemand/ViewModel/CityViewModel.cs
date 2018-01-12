using BusinessLib;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    public class CityViewModel : TreeViewItemViewModel
    {
        readonly City _city;

        public CityViewModel(City city, StateViewModel parentState)
            : base(parentState, false)
        {
            _city = city;
        }

        public string CityName
        {
            get { return _city.CityName; }
        }
    }
}