using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace KarveDataServices.ViewObjects
{
    public class BookingConfirmMessageViewObject: BaseViewObject
    {
        [Display(Name="Codigo")]
        public override string Code { set; get; }
        [Display(Name = "Language")]
        public byte? Language { set; get; }
        [Display(Name = "Nombre")]
        public override string Name { set; get; }
        [Display(Name = "Texto")]
        public string Text { set; get; }
        [Display(Name ="Titulo")]
        public string Title { set; get; }

    }
}
