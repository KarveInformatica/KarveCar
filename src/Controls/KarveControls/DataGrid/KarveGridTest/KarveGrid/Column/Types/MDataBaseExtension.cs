using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KarveGrid.Column.Types
{
    /* This is a mixin interface.
     * In object-oriented programming languages, a mixin is a class that contains methods for use by other classes without having to be the parent class of those other classes. 
     * How those other classes gain access to the mixin's methods depends on the language. Mixins are sometimes described as being "included" rather than "inherited".
     * Mixins encourage code reuse and can be used to avoid the inheritance ambiguity that multiple inheritance can cause (the "diamond problem"),
     * or to work around lack of support for multiple inheritance in a language. A mixin can also be viewed as an interface with implemented methods. 
     * In this case we use to avoid replication when needed.
     */
    public interface IMixinDataBaseExtension
    {
        int Item { set; get; }
        string ExtendedFieldName { set; get; }
        string Table { set; get; }
        string ExpressionDb { set; get; }
        System.Drawing.Color BackGroundColor { set; get; }
       

    }

    public static class MDataBaseExtension
    {

        #region Private Data
        // 
        // ConditionalWeakTable is a way to attach arbitrary data to a particular 
        // instance. It is not simply a dictionary mapping values to instances as keys, 
        // but rather has special run time support to attach directly to instances.
        //
        // This has some interesting ramifications, mainly around object lifetime and 
        // how keys are mapped at runtime: each key must be unique, GetHashCode doesn't 
        // cut it. See the doc for that class for more info.
        /// <summary>
        /// Mixin Private Data Fields
        /// </summary>
       private sealed class Fields
        {
            internal int _item;
            internal string _extendedFieldName;
            internal string _table;
            internal string _expressionDb;
            internal System.Drawing.Color _backGroundColor;
        
            public Fields()
            {
                _item = 0;
                _extendedFieldName = "";
                _table = "";
                _expressionDb = "";
                _backGroundColor = System.Drawing.Color.White;
            }
        }

        private static ConditionalWeakTable<IMixinDataBaseExtension, Fields> _pdata =
            new ConditionalWeakTable<IMixinDataBaseExtension, Fields>();

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        private static Fields GetPrivateData(IMixinDataBaseExtension instance)
        {
            // This is a helper method that retrieves the _PData for a particular
            // instance, or creates it. This is where you'd write your own code for 
            // the setup of the mixin data.
            return _pdata.GetOrCreateValue(instance);
        }

        #endregion

        
        public static int GetItem(this IMixinDataBaseExtension instance)
        {
            return GetPrivateData(instance)._item;
        }
        public static string GetExtendedFieldName(this IMixinDataBaseExtension instance)
        {
            return GetPrivateData(instance)._extendedFieldName;
        }
        public static string GetTable(this IMixinDataBaseExtension instance)
        {
            return GetPrivateData(instance)._table;
        }
        public static string GetExpressionDb(this IMixinDataBaseExtension instance)
        {
            return GetPrivateData(instance)._expressionDb;
        }

        public static void SetItem(this IMixinDataBaseExtension instance, int value)
        {
            GetPrivateData(instance)._item = value;
        }

        internal static System.Drawing.Color GetBackgroundColor(this IMixinDataBaseExtension instance)
        {
            return GetPrivateData(instance)._backGroundColor;
        }

        internal static void SetBackgroundColor(this IMixinDataBaseExtension instance, System.Drawing.Color value)
        {
            GetPrivateData(instance)._backGroundColor = value;
        }

        public static void SetExtendedFieldName(this IMixinDataBaseExtension instance, string value)
        {
            GetPrivateData(instance)._extendedFieldName = value;
        }
        public static void SetTable(this IMixinDataBaseExtension instance, string value)
        {
            GetPrivateData(instance)._table = value;
        }
        public static void SetExpressionDb(this IMixinDataBaseExtension instance, string value)
        {
            GetPrivateData(instance)._expressionDb = value;
        }

    }
}
