using System;
using ExtendedGrid.Classes;

namespace ExtendedGrid.Interface
{
    interface IExtendedColumn
    {
        Boolean AllowAutoFilter { get; set; }
        bool HasAutoFilter { get; }
        SummaryColumnSettings SummaryColumnSettings { get; set; }
    }
}
