using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using KarveDataServices.DataTransferObject;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Windows.Input;
using System.Diagnostics.Contracts;
using System.Windows;
using KarveDataServices.Assist;


namespace KarveControls
{
    /// <summary>
    ///  Class DirectionObject.
    /// 
    /// </summary>
    public class DirectionObject
    {
        /// <summary>
        ///  Direction of payment
        /// </summary>
        public string DIR_PAGO { set; get; }
        /// <summary>
        ///  Second direction of payment
        /// </summary>
        public string DIR2_PAGO { set; get; }
        /// <summary>
        ///  City of paymenet
        /// </summary>
        public string POB_PAGO { set; get; }
        /// <summary>
        ///  Country of payment
        /// </summary>
        public string PAIS_PAGO { set; get; }
        /// <summary>
        ///  Province of payment
        /// </summary>
        public string PROV_PAGO { set; get; }
        /// <summary>
        ///  Mail fo payment
        /// </summary>
        public string MAIL_PAGO { set; get; }
        /// <summary>
        ///  Phone payment
        /// </summary>
        public string TELF_PAGO { set; get; }
        /// <summary>
        ///  Fax payment
        /// </summary>
        public string FAX_PAGO { set; get; }
    }

    

    /// <summary>
    ///  DomainWrapper.
    /// </summary>
    class DomainWrapper: BindableBase
    {
       private DirectionObject info = new DirectionObject();

       public DirectionObject Value
        {
          set { info = value; RaisePropertyChanged();}
          get { return info; }
        }
    }
    public class DirectionInfoViewModelMock: BindableBase
    {
        private DomainWrapper _dataObject = new DomainWrapper();  
        private ObservableCollection<ProvinciaDto> _provinciaDto = new ObservableCollection<ProvinciaDto>()
        {
            new ProvinciaDto()
            {
                Code = "01",
                Country = "Spain",
                Name = "Barcelona"
            },
            new ProvinciaDto()
            {
                Code = "02",
                Country = "Spain",
                Name = "Malaga"
            },
            new ProvinciaDto()
            {
                Code = "03",
                Country = "Spain",
                Name = "Victoria-Gasteiz"
            }

        };
        private ObservableCollection<CityDto> _cityDtos = new ObservableCollection<CityDto>()
        {
            new CityDto()
            {
               
                Code = "01",
                Pais = "Spain",
                Poblacion = "Barcelona"
            },
            new CityDto()
            {
                Code = "02",
                Pais = "Spain",
                Poblacion = "Malaga"
            },
            new CityDto()
            {
                Code= "03",
                Pais = "Spain",
                Poblacion = "Victoria-Gasteiz"
            }

        };

        private ObservableCollection<CountryDto> GetCountries()
        {
            ObservableCollection<CountryDto> countryDtos = new ObservableCollection<CountryDto>()
            {
                new CountryDto()
                {
                    Code = "34",
                    CountryName = "Spain"
                },
                new CountryDto()
                {
                    Code = "39",
                    CountryName = "Italy"
                },
                new CountryDto()
                {
                    Code = "49",
                    CountryName = "Germany"
                },
                new CountryDto()
                {
                    Code = "44",
                    CountryName = "UK"
                }
            };
            return countryDtos;
        }

        private ObservableCollection<CountryDto> _countryDtos = new ObservableCollection<CountryDto>();
        

        private ICommand _assistCommand;
        private ICommand _itemChangedCommand;
        private DirectionObject _directionObject;

        /// <summary>
        ///  AssistCommand.
        /// </summary>
        public ICommand AssistCommand {
            set { _assistCommand = value; }
            get { return _assistCommand; }
        }

        public ICommand ItemChangedCommand
        {
            set { _itemChangedCommand = value; }
            get { return _itemChangedCommand; }
        }
        /// <summary>
        ///  CountryDto
        /// </summary>
        public ObservableCollection<CountryDto> CountryDto {
            set { _countryDtos = value; RaisePropertyChanged(); }
            get { return _countryDtos; } }
        /// <summary>
        ///  CityDto
        /// </summary>
        public ObservableCollection<CityDto> CityDto {
            set { _cityDtos = value; RaisePropertyChanged();}
            get { return _cityDtos; } }

        /// <summary>
        ///  ProvinciaDto.
        /// </summary>
        public ObservableCollection<ProvinciaDto> ProvinceDto
        {
            set { _provinciaDto = value; RaisePropertyChanged(); }
            get { return _provinciaDto; }
        }

        public DirectionInfoViewModelMock()
        {
            DirectionObject entity = new DirectionObject();
            entity.DIR2_PAGO = "Calle Paris 57";
            entity.DIR_PAGO = "Avenida Roma 34";
            entity.FAX_PAGO = "+3493893489";
            entity.MAIL_PAGO = "giorgio.zoppi@gmail.com";
            entity.PAIS_PAGO = "44";
            entity.POB_PAGO = "01";
            entity.PROV_PAGO = "01";
            entity.TELF_PAGO = "+3458598595";
            _dataObject = new DomainWrapper();
            _dataObject.Value = entity;
            AssistCommand = new DelegateCommand<object>(OnAssist);
            ItemChangedCommand = new DelegateCommand<object>(OnItemChanged);
            DataObject = _dataObject;

        }
        public DirectionObject DirInfo
        {
         set { _directionObject = value; RaisePropertyChanged(); }
         get { return _directionObject; }
        }


        private void OnItemChanged(object value)
        {
            Contract.Requires(value != null);
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>)value;
            if (eventDictionary.ContainsKey("DataObject"))
            {
              
              var tmp  = eventDictionary["DataObject"];
              DataObject = tmp;
              DomainWrapper wrapper = tmp as DomainWrapper;
              if (wrapper != null)
              {
                   DirInfo = wrapper.Value;
              }
              Contract.Requires(DataObject != null);       
            }
        }

        private void OnAssist(object value)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)value;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            // FIXME i have find no way to avoid return type case.
            switch (assistTableName)
            {
                case "CITY_ASSIST":
                {
                    CityDto = GetCities();
                    break;
                }
                case "COUNTRY_ASSIST":
                {
                    CountryDto = GetCountries();
                    break;
                }
                case "PROV_ASSIST":
                {
                    ProvinceDto = GetProvince();
                    break;
                }
            }
            Contract.Ensures(!string.IsNullOrEmpty(assistTableName));
        }

        private ObservableCollection<CityDto> GetCities()
        {
            ObservableCollection<CityDto> _cityDtos = new ObservableCollection<CityDto>()
            {
                new CityDto()
                {

                    Code = "01",
                    Pais = "Spain",
                    Poblacion = "Barcelona"
                },
                new CityDto()
                {
                    Code = "02",
                    Pais = "Spain",
                    Poblacion = "Malaga"
                },
                new CityDto()
                {
                    Code = "03",
                    Pais = "Spain",
                    Poblacion = "Victoria-Gasteiz"
                }
            };
            return _cityDtos;
        }
        private ObservableCollection<ProvinciaDto> GetProvince()
        {
            ObservableCollection<ProvinciaDto> cityDtos = new ObservableCollection<ProvinciaDto>()
            {
                new ProvinciaDto()
                {
                    Code = "01",
                    Country = "Spain",
                    Name = "Barcelona"
                },
                new ProvinciaDto()
                {
                    Code = "02",
                    Country = "Spain",
                    Name = "Malaga"
                },
                new ProvinciaDto()
                {
                    Code = "03",
                    Country = "Spain",
                    Name = "Victoria-Gasteiz"
                }

            };
            return cityDtos;
        }

        public object DataObject
        {
         set { _dataObject = (DomainWrapper)value; RaisePropertyChanged(); }
         get { return _dataObject; }
        } 
    }
}
