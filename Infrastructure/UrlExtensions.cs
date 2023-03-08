using Microsoft.AspNetCore.Http;

namespace Mission9_DexterStephens.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
        }
    }
}
