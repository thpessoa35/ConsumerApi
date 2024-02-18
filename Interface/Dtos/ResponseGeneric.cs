using System.Dynamic;
using System.Net;

namespace ApiServiceDto
{
    public class ResponseGeneric<T> where T : class
    {
        public HttpStatusCode CodigoHttp { get; set; }
        public T? GetValue { get; set; }
        public ExpandoObject? ErrorResponse { get; set; }
    }
}