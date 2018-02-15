using System;
using System.Collections.Generic;

namespace KarveCommonInterfaces
{ 
    public interface IValidationChain<T>
    {
        bool Validate(T entity);
        IList<string> Errors { set; get; }
       // QueryStore Store { get; set; }
    }
}