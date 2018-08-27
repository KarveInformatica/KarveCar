using System;
using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  Office data
    /// </summary>
    public class Office : DomainObject, IOfficeData
    {
        private OfficeViewObject _value = new OfficeViewObject();
        private IEnumerable<ZonaOfiViewObject> _zonaOfiDtos = new List<ZonaOfiViewObject>();
        private IEnumerable<ProvinceViewObject> _provinciaDtos = new List<ProvinceViewObject>();
        private IEnumerable<CountryViewObject> _countryDtos = new List<CountryViewObject>();
        private IEnumerable<CityViewObject> _cityDtos = new List<CityViewObject>();
        private IEnumerable<ClientZoneViewObject> _clientZoneDtos = new List<ClientZoneViewObject>();
        private IEnumerable<CurrenciesViewObject> _currencies = new List<CurrenciesViewObject>();
        private IEnumerable<DelegaContableViewObject> _contableDelegation = new List<DelegaContableViewObject>();

        public Office() 
        {
            Valid = false;
        }
        /// <summary>
        ///  This returns the value of an office.
        /// </summary>
        public OfficeViewObject Value
        {
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
            get
            {
                return _value;
            }
        }
        /// <summary>
        ///  Check if the province is valid or not.
        /// </summary>
        public IEnumerable<ProvinceViewObject> ProvinciaDto
        {
            get => _provinciaDtos;
            set { _provinciaDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        ///  Check if the country is valid or not.
        /// </summary>
        public IEnumerable<CountryViewObject> CountryDto
        {
            get => _countryDtos;
            set { _countryDtos = value; RaisePropertyChanged();}
        }

        /// <summary>
        ///  Check if the city is valid or not.
        /// </summary>
        public IEnumerable<CityViewObject> CityDto
        {
            get => _cityDtos;
            set { _cityDtos = value; RaisePropertyChanged();}
        }

        /// <summary>
        ///  Office zone viewObject.
        /// </summary>
        public IEnumerable<ZonaOfiViewObject> ClientZoneDto
        {
            get => _zonaOfiDtos;
            set { _zonaOfiDtos = value ?? throw new ArgumentNullException(nameof(value)); RaisePropertyChanged(); }
        }

        // Client zone viewObject.
        public IEnumerable<ClientZoneViewObject> ZoneDto
        {
            get => _clientZoneDtos;
            set { _clientZoneDtos = value; RaisePropertyChanged();}
        }

        public IEnumerable<DelegaContableViewObject> ContableDelegaDto {
            get => _contableDelegation;
            set { _contableDelegation = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// CurrenciesViewObject.
        /// </summary>
        public IEnumerable<CurrenciesViewObject> CurrenciesDto
        {
            get => _currencies;
            set { _currencies = value; RaisePropertyChanged(); }
        }

}

}