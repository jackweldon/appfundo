using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Fundo.Core.Model;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace Fundo.Core.RestService
{
    interface IFundoRestService
    {
        void PostLike();
        void PostDislike();

        List<ToDoItem> GetUserLikes();
        Task<List<ToDoItem>> SearchToDoItemsAsync(SearchModel model);

    }

    interface IUserRestService
    {
        AppUser CreateOrGetUser();
    }

    public class FundoHttpClient : HttpClient
    {
        
        public FundoHttpClient()
        {
            BaseAddress = new Uri("http://developer.xamarin.com:8081/api/");
            MaxResponseContentBufferSize = 256000;
        }
    }

    public class FundoRestService : IFundoRestService
    {
        private readonly HttpClient _client = new FundoHttpClient();

        public async Task<List<ToDoItem>> SearchToDoItemsAsync(SearchModel model)
        {
            var uri = _client.BaseAddress + "Search?";
            uri += model.GetSearchParameters();

            var response =await  _client.GetAsync(uri);
            var items = new List<ToDoItem>();

            if (!response.IsSuccessStatusCode) return items;

            var content = await response.Content.ReadAsStringAsync();
            items = JsonConvert.DeserializeObject<List<ToDoItem>>(content);
            return items;
        }

        public void PostLike()
        {
            throw new NotImplementedException();
        }

        public void PostDislike()
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetUserLikes()
        {
            throw new NotImplementedException();
        }

     
    }
}
