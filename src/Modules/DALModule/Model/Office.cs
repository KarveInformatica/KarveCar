using System;
using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Office data
    /// </summary>
    public class Office : DomainObject, IOfficeData
    {
        private OfficeDtos _value = new OfficeDtos();
        private IEnumerable<ZonaOfiDto> _zonaOfiDtos = new List<ZonaOfiDto>();
        private IEnumerable<ProvinciaDto> _provinciaDtos = new List<ProvinciaDto>();
        private IEnumerable<CountryDto> _countryDtos = new List<CountryDto>();
        private IEnumerable<CityDto> _cityDtos = new List<CityDto>();
        private IEnumerable<ClientZoneDto> _clientZoneDtos = new List<ClientZoneDto>();
        private IEnumerable<CurrenciesDto> _currencies = new List<CurrenciesDto>();
        private IEnumerable<DelegaContableDto> _contableDelegation = new List<DelegaContableDto>();

        public Office() 
        {
            Valid = false;
        }
        /// <summary>
        ///  This returns the value of an office.
        /// </summary>
        public OfficeDtos Value
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
        public IEnumerable<ProvinciaDto> ProvinciaDto
        {
            get => _provinciaDtos;
            set { _provinciaDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        ///  Check if the country is valid or not.
        /// </summary>
        public IEnumerable<CountryDto> CountryDto
        {
            get => _countryDtos;
            set { _countryDtos = value; RaisePropertyChanged();}
        }

        /// <summary>
        ///  Check if the city is valid or not.
        /// </summary>
        public IEnumerable<CityDto> CityDto
        {
            get => _cityDtos;
            set { _cityDtos = value; RaisePropertyChanged();}
        }

        /// <summary>
        ///  Office zone dto.
        /// </summary>
        public IEnumerable<ZonaOfiDto> ClientZoneDto
        {
            get => _zonaOfiDtos;
            set { _zonaOfiDtos = value ?? throw new ArgumentNullException(nameof(value)); RaisePropertyChanged(); }
        }

        // Client zone dto.
        public IEnumerable<ClientZoneDto> ZoneDto
        {
            get => _clientZoneDtos;
            set { _clientZoneDtos = value; RaisePropertyChanged();}
        }

        public IEnumerable<DelegaContableDto> ContableDelegaDto {
            get => _contableDelegation;
            set { _contableDelegation = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// CurrenciesDto.
        /// </summary>
        public IEnumerable<CurrenciesDto> CurrenciesDto
        {
            get => _currencies;
            set { _currencies = value; RaisePropertyChanged(); }
        }

}

}