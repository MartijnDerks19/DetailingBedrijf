using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Exceptions
{
    public class DeZaakIsGeslotenException : Exception
    {
        public DeZaakIsGeslotenException() : base()
        {

        }

        public DeZaakIsGeslotenException(string message) : base(message)
        {

        }

        public DeZaakIsGeslotenException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
