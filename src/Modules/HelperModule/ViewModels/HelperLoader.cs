using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  TODO: fix the srp issues.
    /// </summary>
    /// <typeparam name="Dto"></typeparam>
    /// <typeparam name="Entity"></typeparam>
    public class HelperLoader<Dto, Entity> where Dto: class
                                           where Entity: class
    {
        private IDataServices _services;
        private ObservableCollection<Dto> _helperView;
        private INotifyTaskCompletion<IEnumerable<Dto>> _initializationNotifier;
        private PropertyChangedEventHandler _loadCompleted;

        public HelperLoader(IDataServices services)
        {
            _services = services;
            _loadCompleted += OnLoadCompleted;

        }
        // TODO: check error.
        private void OnLoadCompleted(object sender, PropertyChangedEventArgs e)
        {
           
           
        }

        /// <summary>
        ///  Load event.
        /// </summary>
        /// <param name="value"></param>
        public void Load(string value)
        {
            _initializationNotifier = NotifyTaskCompletion.Create(LoadDto(value), _loadCompleted);

        }
        /// <summary>
        ///  Load all the entities.
        /// </summary>
        public void LoadAll()
        {
            _initializationNotifier = NotifyTaskCompletion.Create(LoadDtoAll(), _loadCompleted);
        }

        /// <summary>
        ///  Load Data Transfer All. Violate SRP.
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<Dto>> LoadDtoAll()
        {
            IEnumerable<Dto> list = null;
            try

            {
                list = await _services.GetHelperDataServices().GetMappedAllAsyncHelper<Dto, Entity>();
            }
            catch (Exception e)
            {
                throw new DataLayerException(e.Message, e);
            }
            if (list == null)
            {
                return null;
            }
            var value = new ObservableCollection<Dto>(list);
            _helperView = value;
            return value;
        }
        /// <summary>
        ///  HelperView.
        /// </summary>
        public ObservableCollection<Dto> HelperView
        {
            set { _helperView = value; }
            get { return _helperView; }
        }
        /// <summary>
        ///  This load a data transfer object.
        /// </summary>
        /// <param name="query">This load a dto.</param>
        /// <returns></returns>
        private async Task<IEnumerable<Dto>> LoadDto(string query) 
        {
            var listOfVehicles = await _services.GetHelperDataServices()
                .GetMappedAsyncHelper<Dto, Entity>(query);
            if (listOfVehicles == null)
            {
                return null;
            }
            var value = new ObservableCollection<Dto>(listOfVehicles);
            _helperView = value;
            return value;
        }
    } 
}
