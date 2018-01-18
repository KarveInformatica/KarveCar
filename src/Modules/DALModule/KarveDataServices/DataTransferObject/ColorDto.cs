namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Data Transfer Object for a color.
    /// </summary>
    public class ColorDto : BaseDto
    {
        /// <summary>
        ///  codigo of the color.
        /// </summary>
        public string Codigo { get;  set; }
        /// <summary>
        ///  name of the color
        /// </summary>
        public string Nombre { get;  set; }
        /// <summary>
        ///  metalizad
        /// </summary>
        public bool PowderCoating { get; set; }
        /// <summary>
        ///  tow color
        /// </summary>
        public bool TwoTone { get; set; }
        /// <summary>
        ///  No coating
        /// </summary>
        public bool NoCoating { get; set; }
    }
}