﻿using System.Windows;
using System.Windows.Input;
using System;
using Syncfusion.UI.Xaml.Grid;
using System.IO;
using KarveCommon.Generic;

namespace KarveControls
{
    /// <summary>
    ///  This is a public class that cfor the karve grid. This is a set of attached properties used to:
    ///  1. Assign to each datagrid an unique identifier in the system.
    ///  2. Let each grid reguister its identifier in the system.
    ///  3. Store the grid parameter and invoke a command when the user change size and dimension of the grid.
    /// </summary>
    public class KarveGridExt : DependencyObject
    {
        /// <summary>
        ///  State enum to keep trace of the resize.
        /// </summary>
        enum ResizeState
        {
            NoResize,       //No resize of the state of the grid. When i have to resize a column.
            StartResize     // Resize of the state of the grid
        }

        /// <summary>
        ///  Each grid has an unique identifier.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItems",
                typeof(object),
                typeof(KarveGridExt),
                new PropertyMetadata(new object(), OnSelectedItem));

        private static void OnSelectedItem(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SfDataGrid dataGrid = d as SfDataGrid;
            if (dataGrid != null)
            {

                dataGrid.SelectionChanged += DataGrid_SelectionChanged;
                    
            }
        }

        private static void DataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            SfDataGrid dataGrid = sender as SfDataGrid;
            SetSelectedItems(dataGrid, e.AddedItems);
        }

        public static void SetSelectedItems(DependencyObject d, object value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }
        public static object GetSelectedItems(DependencyObject d)
        {
            return d.GetValue(SelectedItemsProperty);
        }


        /// <summary>
        ///  Resize of the current state.
        /// </summary>
        private static ResizeState _currentState = ResizeState.NoResize;
        /// <summary>
        ///  Each grid has an unique identifier.
        /// </summary>
        public static readonly DependencyProperty GridIdentifierProperty =
            DependencyProperty.RegisterAttached(
                "GridIdentifier",
                typeof(long),
                typeof(KarveGridExt),
                new PropertyMetadata(long.MinValue, OnIdChanged));

        private static void OnIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICommand command = GetGridInitCommand(d, e);
            if (command != null)
            {
                long value = GetGridIdentifier(d, e);
                KarveGridParameters parameters = new KarveGridParameters();
                parameters.GridIdentifier = value;
                command.Execute(parameters);
            }
        }


        /// <summary>
        ///  Set the GridIdentifier dependency property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Depndency Property event</param>
        public static void SetGridIdentifier(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(GridIdentifierProperty, e);
        }

        /// <summary>
        /// Get the GridIdentifier Dependency Property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Dependency Property events</param>
        public static long GetGridIdentifier(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return (long) d.GetValue(GridIdentifierProperty);
        }

        /// <summary>
        /// Dependency property for leveraging the command.
        /// </summary>
        public static readonly DependencyProperty GridInitCommandProperty =
            DependencyProperty.RegisterAttached(
                "GridInitCommand",
                typeof(ICommand),
                typeof(KarveGridExt), new PropertyMetadata(null, OnGridInitChangedCommand));

        private static void OnGridInitChangedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            ICommand command = (ICommand) d.GetValue(GridInitCommandProperty);
            long value = GetGridIdentifier(d, e);
            if (value != long.MinValue)
            {
                KarveGridParameters parameters = new KarveGridParameters();
                parameters.GridIdentifier = value;
                if (command != null)
                {
                    command.Execute(parameters);
                }
            }
        }
        /// <summary>
        ///  Set the GridParameters dependency property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Depndency Property event</param>
        public static void SetGridInitCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(GridInitCommandProperty, e);
        }

        /// <summary>
        /// This set the grid param changed command
        /// </summary>
        /// <param name="d">GridInitCommand Dependency Property</param>
        /// <param name="e">Events</param>
        /// <returns></returns>
        public static ICommand GetGridInitCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return (ICommand) d.GetValue(GridInitCommandProperty);
        }

        /// <summary>
        ///  Each grid has an unique identifier.
        /// </summary>
        public static readonly DependencyProperty GridNameProperty =
            DependencyProperty.RegisterAttached(
                "GridName",
                typeof(string),
                typeof(KarveGridExt));

        /// <summary>
        ///  Set the GridIdentifier dependency property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Depndency Property event</param>
        public static void SetGridName(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(GridNameProperty, e);
        }

        /// <summary>
        /// Get the GridIdentifier dependecy property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Dependency Property events</param>
        public static string GetGridName(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return (string) d.GetValue(GridNameProperty);
        }

        /// <summary>
        ///  Grid parameters to be set and serialized when changed 
        /// </summary>
        public static readonly DependencyProperty GridParametersProperty =
            DependencyProperty.RegisterAttached(
                "GridParameters",
                typeof(KarveGridParameters),
                typeof(KarveGridExt),
                new PropertyMetadata(new KarveGridParameters()));

        /// <summary>
        ///  Set the GridParameters dependency property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Depndency Property event</param>
        public static void SetGridParameters(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(GridParametersProperty, e);
        }
        /// <summary>
        /// Get the GridParameters dependecy property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Dependency Property events</param>
        public static KarveGridParameters GetGridParameter(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return (KarveGridParameters) d.GetValue(GridParametersProperty);
        }
        /// <summary>
        /// Dependency property for leveraging the command.
        /// </summary>
        public static readonly DependencyProperty GridParamChangedCommandProperty =
            DependencyProperty.RegisterAttached(
                "GridParamChangedCommand",
                typeof(ICommand),
                typeof(KarveGridExt), new PropertyMetadata(null, OnGridParmChangedCommand));
        /// <summary>
        ///  GridParamChanged. This command changes the param.
        /// </summary>
        /// <param name="d">Syncfusion DataGrid</param>
        /// <param name="e"></param>
        private static void OnGridParmChangedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SfDataGrid dataGrid = d as SfDataGrid;
            if (dataGrid != null)
            {
                dataGrid.ResizingColumns += DataGrid_ResizingColumns;
                dataGrid.MouseLeave += DataGrid_MouseLeave;
                dataGrid.QueryColumnDragging += DataGrid_QueryColumnDragging;
                dataGrid.ItemsSourceChanged += DataGrid_ItemsSourceChanged;
            }
        }
        /// <summary>
        ///  ItemChangeSource Changed event. In this function in case of autogenerate column we enforce the parameters load.
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">Source of the event</param>
        private static void DataGrid_ItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e)
        {
            var dataGrid = sender as SfDataGrid;
            if (dataGrid != null)
            {
                DependencyPropertyChangedEventArgs ev = new DependencyPropertyChangedEventArgs();
                KarveGridParameters parm = GetGridParameter(dataGrid, ev);
                LoadParameters(dataGrid, parm.Xml);
               
            }
        }
        /// <summary>
        ///  Set the GridParameters dependency property.
        /// </summary>
        /// <param name="d">Dependency Property</param>
        /// <param name="e">Depndency Property event</param>
        public static void SetGridParamChangedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(GridParamChangedCommandProperty, e);
        }

        /// <summary>
        /// This set the grid param changed command
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static ICommand GetGridParamChangedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return (ICommand) d.GetValue(GridParamChangedCommandProperty);
        }

      
        /// <summary>
        ///  This load the parameters
        /// </summary>
        /// <param name="dataGrid">DataGrid to be used</param>
        /// <param name="serializedString">The serialized string to be used</param>

        private static void LoadParameters(SfDataGrid dataGrid, string serializedString)
        {
            DeserializationOptions options = new DeserializationOptions();
            options.DeserializeFiltering = false;
            if (string.IsNullOrEmpty(serializedString))
            {
                return;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(ms))
                {
   

                    writer.Write(serializedString);
                    writer.Flush();
                    byte[] byteArray = ms.ToArray();
                    using (MemoryStream reader = new MemoryStream(byteArray))
                    {
                        dataGrid.Deserialize(reader, options);

                    }
                }
            }
        }

        /// <summary>
        /// Serialize and save in a string the grid parameters.
        /// </summary>
        /// <param name="grid">Data Grid to be saved.</param>
        /// <param name="serializedString">String to be serialized.</param>
        private static void SaveParameters(SfDataGrid grid, out string serializedString)
        {
            var dependencyObject = grid as DependencyObject;
            serializedString = String.Empty;

            DependencyPropertyChangedEventArgs ev = new DependencyPropertyChangedEventArgs();
            ICommand command = GetGridParamChangedCommand(dependencyObject, ev);
            using (MemoryStream ms = new MemoryStream())
            {
                if (grid != null)
                {

                    grid.Serialize(ms);
                    byte[] valueArray = ms.ToArray();
                    StreamReader reader = new StreamReader(new MemoryStream(valueArray));
                    var xmlString = reader.ReadToEnd();
                    serializedString = xmlString;
                    KarveGridParameters karveGrid = GetGridParameter(grid, ev);
                    if (karveGrid != null)
                    {
                        karveGrid.GridIdentifier = GetGridIdentifier(dependencyObject, ev);
                        karveGrid.GridName = GetGridName(dependencyObject, ev);
                        karveGrid.PreviousXml = karveGrid.PreviousXml;
                        karveGrid.Xml = xmlString;
                        command?.Execute(karveGrid);
                    }
                }
            }
        }

        private static void DataGrid_QueryColumnDragging(object sender, QueryColumnDraggingEventArgs e)
        {
            if (e.Reason == QueryColumnDraggingReason.Dropped)
            {
                SfDataGrid grid = sender as SfDataGrid;
                string savedParams = string.Empty;
                SaveParameters(grid, out savedParams);
                if (!string.IsNullOrEmpty(savedParams))
                {
                    LoadParameters(grid, savedParams);
                }
            }

        }

        private static void DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
           
          var grid = sender as SfDataGrid;
            if (_currentState == ResizeState.StartResize)
            {
                string savedParams = string.Empty;
                SaveParameters(grid, out savedParams);
                if (!string.IsNullOrEmpty(savedParams))
                {
                    LoadParameters(grid, savedParams);
                }
                _currentState = ResizeState.NoResize;
            }
           
        }
        private static void DataGrid_ResizingColumns(object sender, ResizingColumnsEventArgs e)
        {
            _currentState = ResizeState.StartResize;
        }
         
    }

}