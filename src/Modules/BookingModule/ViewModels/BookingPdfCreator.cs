using KarveDataServices.DataTransferObject;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.IO;
using System.Windows;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  This object has the responsability to create a pdf from a stream.
    /// </summary>
    public class BookingPdfCreator
    {
        private BookingDto _dtoValue;
        private MemoryStream _imageStream;

        /// <summary>
        ///  Create a booking from a pdf or a memory image stream.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="image"></param>
        public BookingPdfCreator(BookingDto dto, MemoryStream image)
        {
            _dtoValue = dto;
            _imageStream = image;
        }
        public MemoryStream CreatePdf()
        {

            MessageBox.Show("Crystal report integration not done");
            return null;
            /*
            var memoryStream = new MemoryStream();

             PdfDocument document = new PdfDocument();

            //Add a page to the document.

            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page.

            PdfGraphics graphics = page.Graphics;

            PdfImage image = PdfImage.FromStream(_imageStream);
            //Set the standard font.

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            graphics.DrawImage(image, new PointF(0, 0));
            //Draw the text.
            graphics.DrawString(_dtoValue.LINEA1ROT_RES2, font, PdfBrushes.Black, new PointF(0, image.Height+10));
            graphics.DrawString(_dtoValue.LINEA2ROT_RES2, font, PdfBrushes.Black, new PointF(0, image.Height+50));
            graphics.DrawString(_dtoValue.LINEA3ROT_RES2, font, PdfBrushes.Black, new PointF(0, image.Height+100));
            //Save the document.
            document.Save(memoryStream);
            //Close the document.
            document.Close(true);
            return memoryStream; */

        }
    }
}
