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
    ///  Control masked text box. A text box where you can put a mask.
    /// </summary>
    public class MaskedTextBox : TextBox
    {
        private System.ComponentModel.MaskedTextProvider _mprovider = null;
        /// <summary>
        /// Gets/Sets the desired mask
        /// </summary>
        public string Mask
        {
            get
            {
                if (_mprovider != null) return _mprovider.Mask;
                else return "";
            }
            set
            {
                _mprovider = new System.ComponentModel.MaskedTextProvider(value);
                this.Text = _mprovider.ToDisplayString();
            }
        }

        private bool PreviousInsertState = false;

        private bool _InsertIsON = false;
        private bool _stayInFocusUntilValid = true;

        /// <summary>
        /// Sets whether the focus should stay on the control until the contents are valid
        /// </summary>
        public bool StayInFocusUntilValid
        {
            get { return _stayInFocusUntilValid; }
            set { _stayInFocusUntilValid = value; }
        }

        private bool _NewTextIsOk = false;
        /// <summary>
        /// Defines whether the next entered input text is ok according to the mask
        /// </summary>
        public bool NewTextIsOk
        {
            get { return _NewTextIsOk; }
            set { _NewTextIsOk = value; }
        }

        private bool _ignoreSpace = true;
        /// <summary>
        /// Sets whether space should be ignored
        /// </summary>
        public bool IgnoreSpace
        {
            get { return _ignoreSpace; }
            set { _ignoreSpace = value; }
        }

        /// <summary>
        /// Stops the effect of some common keys
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (this.SelectionLength > 1)
            {
                this.SelectionLength = 0;
                e.Handled = true;
            }
            if (e.Key == Key.Insert || e.Key == Key.Delete || e.Key == Key.Back || (e.Key == Key.Space && _ignoreSpace))
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);

        }

        /// <summary>
        /// We check whether we are ok
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            System.ComponentModel.MaskedTextResultHint hint;
            int TestPosition;

            if (e.Text.Length == 1)
                this._NewTextIsOk = _mprovider.VerifyChar(e.Text[0], this.CaretIndex, out hint);
            else
                this._NewTextIsOk = _mprovider.VerifyString(e.Text, out TestPosition, out hint);

            base.OnPreviewTextInput(e);

        }

        /// <summary>
        /// When text is received by the TextBox we check whether to accept it or not
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextInput(System.Windows.Input.TextCompositionEventArgs e)
        {
            string PreviousText = this.Text;
            if (NewTextIsOk)
            {
                base.OnTextInput(e);
                if (_mprovider.VerifyString(this.Text) == false) this.Text = PreviousText;
                while (!_mprovider.IsEditPosition(this.CaretIndex) && _mprovider.Length > this.CaretIndex) this.CaretIndex++;

            }
            else
                e.Handled = true;
        }

        /// <summary>
        /// When the TextBox takes the focus we make sure that the Insert is set to Replace
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (!_InsertIsON)
            {
                PressKey(Key.Insert);
                _InsertIsON = true;
            }
        }

        /// <summary>
        /// When the textbox looses the keyboard focus we may want to verify (based on the StayInFocusUntilValid) whether
        /// the control has a valid value (fully complete)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            if (StayInFocusUntilValid)
            {
                _mprovider.Clear();
                _mprovider.Add(this.Text);
                if (!_mprovider.MaskFull) e.Handled = true;
            }

            base.OnPreviewLostKeyboardFocus(e);
        }

        /// <summary>
        /// When the textbox looses its focus we need to return the Insert Key state to its previous state
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            if (PreviousInsertState != System.Windows.Input.Keyboard.PrimaryDevice.IsKeyToggled(System.Windows.Input.Key.Insert))
                PressKey(Key.Insert);
        }

        /// <summary>
        /// Simulates pressing a key
        /// </summary>
        /// <param name="key">The key to be pressed</param>
        private void PressKey(Key key)
        {
            KeyEventArgs eInsertBack = new KeyEventArgs(Keyboard.PrimaryDevice,
                                                        Keyboard.PrimaryDevice.ActiveSource,
                                                        0, key);
            eInsertBack.RoutedEvent = KeyDownEvent;
            InputManager.Current.ProcessInput(eInsertBack);
        }
    }
   }
