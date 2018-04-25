using System;
namespace KarveDataServices
{
    /// <summary>
    ///  This is the magnifier columns stuff.
    /// </summary>
    public interface IMagnifierColumns
    {
        int  ID_COL { set; get; }

        Int32 ID_LUPA { set; get; }
        /// <summary>
        ///  Set or get the Name property.
        /// </summary>
        string COLUMNA_NOMBRE { get; set; }
        /// <summary>
        ///  Set or get the VISIBLE property.
        /// </summary>
        byte? VISIBLE { get; set; }
        /// <summary>
        ///  Set or get the POSICION property.
        /// </summary>
        Int32? POSICION { get; set; }
        /// <summary>
        ///  Set or get the Width property.
        /// </summary>
        Int32? ANCHO { get; set; }
    }
}