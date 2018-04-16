using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace KarveControls.Behaviour
{
    /// <summary>
    ///  This class does the resource management of a behavior for avoiding resource leaks,
    ///  implementing the weak event pattern.
    /// </summary>
    /// <typeparam name="T">Tyoe of the associated object</typeparam>
    public abstract class KarveBehaviorBase<T> : Behavior<T> where T : FrameworkElement
    {
        private bool _isHookedUp;
        private bool _isSetup;
        private WeakReference _weakTarget;

        /// <summary>
        /// Hook or unhook the associated object when it changes.
        /// </summary>
        protected override void OnChanged()
        {
            var target = AssociatedObject;
            if (target != null)
            {
                HookupBehavior(target);
            }
            else
            {
                UnhookBehavior();
            }
        }

        /// <summary>
        /// Hookup the behavior before setup is called.
        /// </summary>
        /// <param name="target"></param>
        private void HookupBehavior(T target)
        {
            if (_isHookedUp) return;
            _weakTarget = new WeakReference(target);
            _isHookedUp = true;

            target.Unloaded += OnTargetUnloaded;
            target.Loaded += OnTargetLoaded;

            SetupBehavior();
        }

        /// <summary>
        /// Unhook the behavior before cleanup is called.
        /// </summary>
        private void UnhookBehavior()
        {
            if (_isHookedUp == false) return;
            _isHookedUp = false;

            var target = AssociatedObject ?? (T)_weakTarget.Target;
            if (target != null)
            {
                target.Unloaded -= OnTargetUnloaded;
                target.Loaded -= OnTargetLoaded;
            }

            CleanupBehavior();
        }

        /// <summary>
        /// Calls the setup method.
        /// </summary>
        private void SetupBehavior()
        {
            if (_isSetup) return;
            _isSetup = true;
            OnSetup();
        }

        /// <summary>
        /// Calls the cleanup method.
        /// </summary>
        private void CleanupBehavior()
        {
            if (_isSetup == false) return;
            _isSetup = false;
            OnCleanup();
        }

        /// <summary>
        /// Setup the behavior.
        /// </summary>
        protected virtual void OnSetup() { }

        /// <summary>
        /// Cleanup the behavior.
        /// </summary>
        protected virtual void OnCleanup() { }

        /// <summary>
        /// Is invoked when the target has been loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTargetLoaded(object sender, RoutedEventArgs e) => SetupBehavior();

        /// <summary>
        /// Is invoked when the target has been unloaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTargetUnloaded(object sender, RoutedEventArgs e) => CleanupBehavior();
    }
   }
