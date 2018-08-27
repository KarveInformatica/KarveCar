namespace DataAccessLayer.Logic
{
    using AutoMapper;

    using DataAccessLayer.DataObjects;

    using KarveDataServices.ViewObjects;

    internal class BookingItems2LineReservation: ITypeConverter<BookingItemsViewObject, LIRESER>
    {
       
        public LIRESER Convert(BookingItemsViewObject source, LIRESER destination, ResolutionContext context)
        {
            var reservationLine = new LIRESER { UNIDAD = this.UnityConversion(source.Unity), CANTIDAD = source.Quantity };
            if (source.Included)
            {
                reservationLine.INCLUIDO = -1;
            }
            else
            {
                reservationLine.INCLUIDO = 0;
            }
            reservationLine.NUMERO = source.Number;
            reservationLine.CLAVE_LR = source.BookingKey;
            reservationLine.FACTURAR = (byte) source.Bill;
            reservationLine.DIAS = source.Days;
            reservationLine.TIPO = source.Type;
            reservationLine.TARIFA = source.Fare;
            reservationLine.COSTEU = source.UnityCost;
            reservationLine.DIAS = source.Days;
            reservationLine.DTO = source.Discount;
            reservationLine.CONCEPTO = source.Concept;
            reservationLine.DESCCON = source.Desccon;
            reservationLine.COSTE = source.Cost;
            reservationLine.GRUPO = source.Group;
            reservationLine.PRECIO = source.Price;
            reservationLine.CANTIDAD = source.Quantity;
            reservationLine.EXTRA = source.Extra;
            reservationLine.SUBTOTAL = source.Subtotal;
            reservationLine.IVA = source.Iva;
            reservationLine.USUARIO = source.CurrentUser;
            reservationLine.ULTMODI = source.LastModification;
            return reservationLine;

        }
        public string UnityConversion(object value)
        {
            string unityValue = string.Empty;
            if (value is int currentIndex)
            {
                switch (currentIndex)
                {
                    case 1:
                        {
                            unityValue = "DIA";
                            break;
                        }
                    case 2:
                        {
                            unityValue = "SEMANA";
                            break;
                        }
                    case 3:
                        {
                            unityValue = "MES";
                            break;
                        }
                    case 4:
                        {
                            unityValue = "QUINCENA";
                            break;
                        }
                    case 5:
                        {
                            unityValue = "UNICO";
                            break;
                        }
                    case 6:
                        {
                            unityValue = "FIN DE SEMANA";
                            break;
                        }

                    default:
                        break;
                }
            }
            return unityValue;
        }
    }
}