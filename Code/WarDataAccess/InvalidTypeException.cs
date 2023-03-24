using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarDataAccess
{
    /// <summary>
    /// Exception for invalid type
    /// </summary>
    public class InvalidTypeException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="givenType">The given type</param>
        /// <param name="shouldBeType">The type it should implement</param>
        public InvalidTypeException(Type givenType, Type shouldBeType) 
            : base($"{givenType} should implement {shouldBeType}")
        {
        }
    }
}
