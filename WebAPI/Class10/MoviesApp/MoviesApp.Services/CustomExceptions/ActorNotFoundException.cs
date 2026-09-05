using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.CustomExceptions
{
    public class ActorNotFoundException : Exception
    {
        public ActorNotFoundException(string message) : base(message) { }
    }
}
