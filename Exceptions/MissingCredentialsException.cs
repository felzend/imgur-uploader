using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurFileUploader.Exceptions
{
    public class MissingCredentialsException : Exception
    {
        public MissingCredentialsException() : base() { }
        public MissingCredentialsException(string message) : base(message) { }
    }
}
