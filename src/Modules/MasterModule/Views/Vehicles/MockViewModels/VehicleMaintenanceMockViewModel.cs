using System.Collections;
using System.Windows.Input;
using KarveDataServices.DataTransferObject;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    /// <summary>
    /// Mock Maintenance View Model.
    /// 

    /*
      <KarveControls:DataDatePicker LabelText="Fin Garantia" Height="35"
                                          KarveControls:ControlExt.DataSource="{Binding DataObject, Mode=OneWay, 
                                          UpdateSourceTrigger=PropertyChanged}"
                                          KarveControls:ControlExt.DataSourcePath="FinGaran"/>
            <Button Content="Calcola Mantenimiento" Height="25" Width="330.437"/>
            <KarveControls:DataField LabelText="Km Actuales"
                                     LabelTextWidth="80"
                                     TextContentWidth="200"
                                     Height="25"
                                     DataObject="{Binding DataObject}"
                                     DataSourcePath="{Binding DataSourcePath}">
            </KarveControls:DataField>
        </WrapPanel>

        <KarveGrid:KarveGridView Grid.Row="1" x:Name="Mantienance" PageSize="25"
                                         TableName="{Binding MaintenanceTableName}" ReadOnly="False" 
                                                     SourceView="{Binding MaintenanceCollection}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="RowMouseDoubleClick">
                    <i:InvokeCommandAction Command="{Binding OpenItem}" CommandParameter="{Binding ElementName=Delegations, Path=SelectedRow}"/>
                </i:EventTrigger>
                <i:EventTrigger EventName="ChangedRows">
                    <mvvm:InvokeCommandAction Command="{Binding DelegationChangedRowsCommand, PresentationTraceSources.TraceLevel=High}" 
                                                                   TriggerParameterPath="RowParameters" />
                </i:EventTrigger>
            </i:Interaction.Triggers>

     */
    /// </summary>
    
    public class VehicleMaintenanceMockViewModel
    {
        /// <summary>
        ///  Open item.
        /// </summary>
        public ICommand OpenItem { set; get; }
        /// <summary>
        ///  Delegation changed rows command
        /// </summary>
        public ICommand DelegationChangedRowsCommand { set; get; }
        /// <summary>
        ///  Data Object
        /// </summary>
        public object DataObject { set; get; }
        /// <summary>
        ///  List of the objects.
        /// </summary>    

    }
}
