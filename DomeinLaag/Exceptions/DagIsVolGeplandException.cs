
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Exceptions
{
    public class DagIsVolGeplandException : Exception
    {
        public DagIsVolGeplandException() : base()
        {
            
        }

        public DagIsVolGeplandException(string message) : base(message)
        {
            
        }

        public DagIsVolGeplandException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
