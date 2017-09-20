
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

public class DataGridColumnVirtuales : Dictionary<string, DataGridColumnVirtual>
{

	public void Add(DataGridColumnVirtual TablaQuery)
	{
		base.Add(TablaQuery.Name, TablaQuery);
	}

    public ArrayList Order()
    {
        dynamic HC = (from c in Values orderby c.Item select c);
        ArrayList RS = new ArrayList();
        foreach (DataGridColumnVirtual ctr in HC)
        {
            RS.Add(ctr);
        }
        return RS;
    }
}

