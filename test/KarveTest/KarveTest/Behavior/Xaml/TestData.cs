using System.Collections.ObjectModel;
namespace KarveTest.Behavior.Xaml
{
    /// <summary>
    ///  This class test the data.
    /// </summary>
    public class TestData
    {
        public ObservableCollection<string> _testData = new ObservableCollection<string>() { "Carlos", "Luis", "Simon" };
        /// <summary>
        ///  TestData
        /// </summary>
        public TestData()
        {
        }
        /// <summary>
        ///  Data to be tested.
        /// </summary>
        /// <returns>This returns a collection</returns>
        public ObservableCollection<string> Data
        {
            set
            {
                _testData = value;
            }
            get
            {
                return _testData;
            }
        }
    }
}
