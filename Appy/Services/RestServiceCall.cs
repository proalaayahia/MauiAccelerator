using Appy.Models;
using Newtonsoft.Json;

namespace Appy.Services;

public class RestServiceCall : IRestServiceCall
{
    //login service
    public async Task<UserBasicInfo> Login(string username, string password, string phoneId)
    {
        try
        {
            UserBasicInfo data = new();
            var client = new HttpClient();
            //username=M_rh50@yahoo.com, pass=M_rh50@yahoo.com,phoneid=zzzzzzzz
            var url = $"https://api.lenuslab.com/?username={username}&password={password}&phoneID=zzzzzzzz";
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<UserBasicInfo>(content);
                return await Task.FromResult(data);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", $"something went wrong,{ex.Message}", "Ok");
            return null;
        }
    }
    //search service
    public async Task<SearchResult> Search(string search, string phoneId)
    {
        try
        {
            SearchResult data = new();
            var client = new HttpClient();
            //      var x = encodeURIComponent("http://a.com/?q=query&n=10");
            var url = $"https://api.lenuslab.com/?s={search}&phoneID=zzzzzzzzzz";
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<SearchResult>(content);
                return await Task.FromResult(data);
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //localization service
    public async Task<object> Translate(string local)
    {
        try
        {
            TranslateResult data = new();
            var client = new HttpClient();
            var url = $" https://api.lenuslab.com/?locale=zz";
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<TranslateResult>(content);
                return await Task.FromResult(data);
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
