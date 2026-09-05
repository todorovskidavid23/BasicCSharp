using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.CustomExceptions
{
    public class DirectorNotFoundException : Exception
    {
        public DirectorNotFoundException(string message) : base(message) { }
    }
}
