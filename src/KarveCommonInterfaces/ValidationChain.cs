using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KarveCommonInterfaces
{
    /// <summary>
    ///  This implements the validation rules as a chain of resposability design pattern.
    /// In object-oriented design, the chain-of-responsibility pattern is a design pattern consisting
    /// of a source of command objects and a series of processing objects.
    /// Each processing object contains logic that defines the types of command objects
    /// that it can handle; the rest are passed to the next processing object in the chain. A
    /// mechanism also exists for adding new processing objects to the end of this chain. Thus,
    /// the chain of responsibility is an object oriented version of the
    /// if ... else if ... else if ....... else ... endif idiom, with the benefit that
    /// the condition action blocks can be dynamically rearranged and reconfigured at runtime.
    /// </summary>
    public abstract class ValidationChain<T> : ISqlValidationRule<T>
    {
        protected ISqlValidationRule<T> Next;
        private string _errorMessage;
        
        /// <summary>
        /// Set or Get an error message in the validation chain
        /// </summary>
        public string ErrorMessage { get ; set ; }
    

        /// <summary>
        /// Set next to make a list of chains
        /// </summary>
        /// <param name="nextRule">Next rule of the chain</param>
        /// <returns></returns>
        public ISqlValidationRule<T> SetNext(ISqlValidationRule<T> nextRule)
        {
            Next = nextRule;
            return Next;
        }

        /// <inheritdoc />
        /// <summary>
        ///  This checks the request coming before saving
        /// </summary>
        /// <param name="request">Request to be checked.</param>
        /// <returns>Returns true if the validation is correct, False otherwise</returns>
        public bool CheckRequest(T request)
        {
            var valid = Validate(request);
            if (!valid)
            {
                return false;
            }
            else
            {
                if (Next != null)
                {
                    valid = Next.CheckRequest(request);
                    if (!valid)
                    {
                        ErrorMessage = Next.ErrorMessage;
                    }
                }
            }
            return valid;
        }
        /// <inheritdoc />
        /// <summary>
        ///  Validate method.
        /// </summary>
        /// <param name="request">This method allows the validation of each request.</param>
        /// <returns>True if the validation is successfully.</returns>
        public abstract bool Validate(T request);
    }
}
