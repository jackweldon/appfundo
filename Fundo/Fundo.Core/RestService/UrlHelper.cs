using System.Reflection;
using Fundo.Core.Model;

namespace Fundo.Core.RestService
{
    public static class UrlHelper
    {
        public static string GetSearchParameters(this SearchModel model)
        {
            var urlString = "";
            foreach (var prop in typeof(SearchModel).GetTypeInfo().DeclaredProperties)
            {
                urlString += prop.Name + "=" + prop.GetValue(prop) + "&";
            }
            return urlString;
        }
    }
}