
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Telerik.WinControls.UI;

namespace KarveControls
{
    public class DataGridColumnGroups : ColumnGroupsViewDefinition
    {
        public void Add(ref GridViewColumnGroup col)
        {
            this.ColumnGroups.Add(col);
        }
    }
}

