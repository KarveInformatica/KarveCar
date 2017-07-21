using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MultiEventCommand.ViewModels
{
    public abstract class ViewModelBase:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected void NotifyPropertyChanged<T, TP>(T source, Expression<Func<T, TP>> pe)
        {
            PropertyChanged.Raise(source, pe);
        }

        #endregion
    }

    ///<summary>
    /// Extension method for handling property changed without strings
    ///</summary>
    public static class PropertyChangedExt
    {
        ///<summary>
        ///</summary>
        ///<param name="pc"></param>
        ///<param name="source"></param>
        ///<param name="pe"></param>
        ///<typeparam name="T"></typeparam>
        ///<typeparam name="TP"></typeparam>
        public static void Raise<T, TP>(this PropertyChangedEventHandler pc, T source, Expression<Func<T, TP>> pe)
        {
            if (pc != null)
            {
                pc.Invoke(source, new PropertyChangedEventArgs(((MemberExpression)pe.Body).Member.Name));
            }
        }
    }
}
