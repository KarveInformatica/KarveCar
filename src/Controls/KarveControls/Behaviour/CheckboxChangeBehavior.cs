
namespace KarveControls.Behaviour
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// The checkbox change behavior.
    /// </summary>
    public class CheckboxChangeBehavior : KarveBehaviorBase<CheckBox>
    {
        /// <summary>
        /// The checked command property.
        /// </summary>
        public static readonly DependencyProperty CheckedCommandProperty = DependencyProperty.Register(
            "CheckedCommand",
            typeof(ICommand),
            typeof(CheckboxChangeBehavior),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets or sets the checked command.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public ICommand CheckedCommand
        {
            get => (ICommand)GetValue(CheckedCommandProperty);

            set => SetValue(CheckedCommandProperty, value);
        }

        /// <inheritdoc />
        /// <summary>
        /// Override of the default behaviour base.
        /// </summary>
        protected override void OnSetup()
        {
            this.AssociatedObject.Checked += this.AssociatedObjectChecked;
            this.AssociatedObject.Unchecked += this.AssociatedObjectUnchecked;
            ///this.AssociatedObject.Click += AssociatedObject_Click;
        }

       
        /// <inheritdoc />
        /// <summary>
        /// Override of the default cleanup base.
        /// </summary>
        protected override void OnCleanup()
        {
            this.AssociatedObject.Checked -= this.AssociatedObjectChecked;
            this.AssociatedObject.Unchecked -= this.AssociatedObjectUnchecked;
        }

        /// <summary>
        ///  Event handler for un checking a box.
        /// </summary>
        /// <param name="sender">Checkbox that send the value</param>
        /// <param name="e">Parameter to be sent</param>
        private void AssociatedObjectUnchecked(object sender, RoutedEventArgs e)
        {
            this.CheckedCommand?.Execute(false);
        }

        /// <summary>
        /// Event handler for checking a box.
        /// </summary>
        /// <param name="sender">
        /// Checkbox that sends the value.
        /// </param>
        /// <param name="e">
        /// Parameter to be sent.
        /// </param>
        private void AssociatedObjectChecked(object sender, RoutedEventArgs e)
        {
            this.CheckedCommand?.Execute(true);

        }
    }
}
