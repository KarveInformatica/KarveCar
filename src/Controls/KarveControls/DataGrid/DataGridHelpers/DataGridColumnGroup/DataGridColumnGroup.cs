
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Telerik.WinControls.UI;

public class DataGridColumnGroup : GridViewColumnGroup
{
	public void Add(ref GridViewDataColumn col)
	{
		this.Rows[0].Columns.Add(col);
	}
	public DataGridColumnGroup()
	{
		this.Rows.Add(new GridViewColumnGroupRow());
	}
}

