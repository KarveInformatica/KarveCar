using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveControls.UIObjects;
using MasterModule.UIObjects.Suppliers;

namespace MasterModule.Common
{
    internal class UiFirstPageBuilder: IUiPageBuilder
    {
        IList<IUiPageBuilder> _pageBuilders = new List<IUiPageBuilder>();
        private UiEmailDataField.EmailCheckHandler _emailCheckHandler;

        public UiEmailDataField.EmailCheckHandler EmailCheckHandler
        {
            get { return _emailCheckHandler; }
            set { _emailCheckHandler = value; }
        }
        public UiFirstPageBuilder()
        {
            _pageBuilders.Add(new UiSuppliersUpperPartPageBuilder());
            _pageBuilders.Add(new UiMiddlePartPageBuilder(EmailCheckHandler));
        }

        private IList<IUiPageBuilder> Builders
        {
            set { _pageBuilders = value; }
            get { return _pageBuilders; }
        }
        public UiFirstPageBuilder(IList<IUiPageBuilder> listOfPageBuilders)
        {
            foreach (IUiPageBuilder pb in listOfPageBuilders)
            {
                _pageBuilders.Add(pb);
            }
        }
        public IDictionary<string, ObservableCollection<IUiObject>> BuildPageObjects(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, UiDfObject.ChangedField changedField)
        {
            IDictionary<string, ObservableCollection<IUiObject>> dictionary = new Dictionary<string, ObservableCollection<IUiObject>>();

            foreach (IUiPageBuilder builder in _pageBuilders)
            {
                IDictionary<string, ObservableCollection<IUiObject>> tmpDictionary = builder.BuildPageObjects(assistQuery, changedField);
                tmpDictionary.ToList().ForEach(x => dictionary.Add(x.Key, x.Value));
            }
            return dictionary;
        }

    }
}
