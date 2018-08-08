using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  BookingIncidentSummaryDto.
    /// </summary>
	public class BookingIncidentSummaryDto : BaseDto
    {

        private string _code;
        private string _booking;
        private string _name;
        private string _notes;
        [Display(Name = "Codigo", Description = "Codigo Incidencia Reserva")]
        public new string Code
        {
            set
            {
                _code = value;
                RaisePropertyChanged("CodeValue");
            }
            get => _code;
        }

        [Display(Name = "Reserva", Description = "Numero Reserva")]
        public string Booking
        {
            set
            {
                _booking = value;
                RaisePropertyChanged("BookingValue");
            }
            get => _booking;
        }

        [Display(Name = "Nombre", Description = "Nombre Incidencia")]
        public new string Name
        {
            set
            {
                _name = value;
                RaisePropertyChanged("NameValue");
            }
            get => _name;
        }

        [Display(Name = "Notes", Description = "Observaciones")]
        public string Notes
        {
            set
            {
                _notes = value;
                RaisePropertyChanged("NotesValue");
            }
            get => _notes;
        }
    }
}