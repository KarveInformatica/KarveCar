using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Prism.Mvvm;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Domain object foreach 
    /// </summary>
    public class DomainObject: BindableBase
    {
        public string Code { get; set; }
        public bool Valid { set; get; }
    }
}