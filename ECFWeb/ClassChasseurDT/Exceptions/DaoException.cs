using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassChasseurDT.Exceptions
{
    public class DaoException : Exception
    {
        public DaoException(): base()
        {
        }

        public DaoException(string message)
            : base(message)
        {
        }
        public DaoException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

    }
}
