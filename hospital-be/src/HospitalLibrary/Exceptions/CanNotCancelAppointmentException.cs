using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Exceptions
{
    public class CanNotCancelAppointmentException : Exception
    {
        public CanNotCancelAppointmentException()
        {

        }

        public CanNotCancelAppointmentException(string message) : base(message) { }
    }
}
