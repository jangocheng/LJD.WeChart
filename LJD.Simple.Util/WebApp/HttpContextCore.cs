
using Microsoft.AspNetCore.Http;

namespace LJD.Simple.Util
{
    public class HttpContextCore
    {
        public static HttpContext Current { get => AutofacHelper.GetService<IHttpContextAccessor>().HttpContext; }
    }
}