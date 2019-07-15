using System;
using System.Collections.Generic;
using System.Net;

namespace Dominos.Common.Classes
{
    public class ResponseEntity<T>
    {
        public ResponseEntity()
        {
            Messages = new List<string>();
            HttpCode = HttpStatusCode.OK;
        }

        public T Result { get; set; }
        public HttpStatusCode HttpCode { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
        public List<string> Messages { get; set; }
    }
}