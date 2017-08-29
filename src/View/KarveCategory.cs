using System.Collections.Generic;

namespace KarveCar.View
{
    public class KarveCategory
    {
         public string CategoryName { set; get; }
        public ICollection<KarveCategory> SubCategories { get; internal set; }
        public KarveCategory ParentCategory { get; internal set; }
    }
}