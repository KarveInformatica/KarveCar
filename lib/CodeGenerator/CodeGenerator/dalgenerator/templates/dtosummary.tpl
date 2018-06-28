using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  {{data.name}}SummaryDto.
    /// </summary>
	public class {{data.name}}SummaryDto: BaseDto
    {
	    {% for d in data.dtofields %}
        private {{d.field_type}} _{{d.field_namelower}};
        {% endfor %}
        {% for info in data.dtofields %}
		[Display(Name = "{{info.field_visualname}}", Description ="{{info.field_desc}}")]
		public {{info.field_type}} {{info.field_name}}Value
       {
           set
           {
               _{{info.field_namelower}} = value;
               RaisePropertyChanged("{{info.field_name}}Value");
           }
           get => _{{info.field_namelower}};
     }
        {% endfor %}
    
    }
   
}
