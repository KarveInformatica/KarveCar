using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KarveControls
{
    /// <summary>
    /// Custom control for computing the amount given an iva.
    /// </summary>
    public class AmountControl : Control
    {
        /// <summary>
        ///  CurrentVat properties.
        /// </summary>
        public static DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(AmountControl));

        /// <summary>
        /// Data object properties.
        /// </summary>
        public static DependencyProperty DataSourceProperty =
            DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(AmountControl));


        public static DependencyProperty DataSourcePathProperty =
    DependencyProperty.Register(
        "DataSourcePath",
        typeof(string),
        typeof(AmountControl));

        /// <summary>
        ///  CurrentVat properties.
        /// </summary>
        public static DependencyProperty CurrentVatProperty =
            DependencyProperty.Register(
                "CurrentVat",
                typeof(double),
                typeof(AmountControl));
        /// <summary>
        ///  Amount properties
        /// </summary>
        public static DependencyProperty AmountProperty =
            DependencyProperty.Register(
                "Amount",
                typeof(decimal?),
                typeof(AmountControl), new PropertyMetadata(null, OnTotalChanged));

      
        /// <summary>
        ///  Total properties
        /// </summary>
        public static DependencyProperty TotalProperty =
            DependencyProperty.Register(
                "Total",
                typeof(double),
                typeof(AmountControl), new PropertyMetadata(0d, OnTotalChanged));
        /// <summary>
        ///  Total properties
        /// </summary>
        public static DependencyProperty ContraTotalProperty =
            DependencyProperty.Register(
                "ContraTotal",
                typeof(decimal?),
                typeof(AmountControl));

        /// <summary>
        ///  Vat on Amount properties
        /// </summary>
        public static DependencyProperty VatOnAmountProperty =
            DependencyProperty.Register(
                "VatOnAmount",
                typeof(decimal?),
                typeof(AmountControl));


        public static DependencyProperty ItemChangedCommandProperty =
       DependencyProperty.Register(
           "ItemChangedCommand",
           typeof(ICommand),
           typeof(AmountControl));
        /// <summary>
        ///  Vat on Contra Amount properties.
        /// </summary>
        public static DependencyProperty VatOnContraAmountProperty =
         DependencyProperty.Register(
            "VatOnContraAmount",
            typeof(decimal?),
            typeof(AmountControl));

        public AmountControl() : base()
        {
        }
        static AmountControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AmountControl), new FrameworkPropertyMetadata(typeof(AmountControl)));

        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        /// <summary>
        ///  Title of the current control.
        /// </summary>
        public object DataSource
        {
            get { return GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        /// <summary>
        ///  Path of the current object
        /// </summary>
        public string DataSourcePath
        {
            get { return (string) GetValue(DataSourcePathProperty); }
            set { SetValue(DataSourcePathProperty, value); }
        }
        
        /// <summary>
        ///  Item changed command 
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get { return (ICommand)GetValue(ItemChangedCommandProperty); }
            set { SetValue(ItemChangedCommandProperty, value); }
        }
        /// <summary>
        ///  Title of the current control.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        /// <summary>
        ///  This returns the current vat.
        /// </summary>
        public double CurrentVat
        {
            get { return (double)GetValue(CurrentVatProperty); }
            set { SetValue(CurrentVatProperty, value); }
        }
        /// <summary>
        ///  This returns the current amount.
        /// </summary>
        public double Amount
        {
            get { return (double)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }
        /// <summary>
        ///  This returns the current vat.
        /// </summary>
        public double VatOnAmount
        {
            get { return (double)GetValue(VatOnAmountProperty); }
            set { SetValue(VatOnAmountProperty, value); }
        }
        /// <summary>
        ///  ContraValor.
        /// </summary>
        public double VatOnContraAmount
        {
            get { return (double)GetValue(VatOnContraAmountProperty); }
            set { SetValue(VatOnContraAmountProperty, value); }
        }
        /// <summary>
        ///  Total valor
        /// </summary>
        public double Total
        {
            get { return (double)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }
        /// <summary>
        ///  ContraTotal
        /// </summary>
        public double ContraTotal
        {
            get { return (double)GetValue(ContraTotalProperty); }
            set { SetValue(ContraTotalProperty, value); }

        }
        /// <summary>
        ///  Total changed is the value changed of the total.
        /// </summary>
        /// <param name="d">Amount control</param>
        /// <param name="e"></param>
        private static void OnTotalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AmountControl control = d as AmountControl;
            if (e.NewValue is double value)
            {
                control.TotalChanged(value);
            }
        }
        private void TotalChanged(double newTotal)
        {
          //  var total = newTotal;
            //Amount = total / (CurrentVat + 1);
        //    VatOnAmount = Amount * CurrentVat;
        }
        private void SetValues(double value)
        {
            // 1. Set Vat
            var currentVat = CurrentVat;
            VatOnAmount = value * currentVat;
            Total = value + VatOnAmount;
        }

    }
}
