using BusinessLib;

namespace TreeViewWithViewModelDemo.LoadOnDemand
{
    public class RegionViewModel : TreeViewItemViewModel
    {
        readonly Region _region;

        public RegionViewModel(Region region) 
            : base(null, true)
        {
            _region = region;
        }

        public string RegionName
        {
            get { return _region.RegionName; }
        }

        protected override void LoadChildren()
        {
            foreach (State state in Database.GetStates(_region))
                base.Children.Add(new StateViewModel(state, this));
        }
    }
}