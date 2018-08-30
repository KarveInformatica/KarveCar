namespace KarveDataServices.ViewObjects
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Input;

    /// <summary>
    /// The user summary view object.
    /// </summary>
    public class UserSummaryViewObject : BaseViewObject
    {
        /// <summary>
        /// User code
        /// </summary>
        private string code;

        /// <summary>
        /// User name
        /// </summary>
        private string name;

        /// <summary>
        /// Password 
        /// </summary>
        private string password;

        private string officeCode;

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [Display(Name = "Code", Description = "Codigo Oficina")]
        public override string Code
        {
            set
            {
                code = value;
                RaisePropertyChanged("CodeValue");
            }
            get => code;
        }

        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        [Display(Name = "Oficina", Description = "Codigo Oficina")]
        public string Office
        {
            set
            {
                officeCode = value;
                RaisePropertyChanged("Office");
            }
            get => officeCode;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Display(Name = "Nombre", Description = "Nombre Incidencia")]
        public string Name
        {
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
            get => name;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Display(Name = "Password", Description = "Password")]
        public string Password
        {
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
            get => password;
        }
    }

}
