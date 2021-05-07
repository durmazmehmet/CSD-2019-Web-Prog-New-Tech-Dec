using CSD.Extensions.Net.Http;
using CSD.WikiInfoSearch.RestClientService.Models;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Tuple;

namespace CSD.WikiInfoSearch.RestClientService.Services
{
    public class WikiInfoService : IWikiInfoService
    {
        private const string ms_baseURL = "http://192.168.1.3:50500/api/";
        private readonly HttpClient m_httpClient;

        public WikiInfoService(HttpClient httpClient) => m_httpClient = httpClient;
       
        public async Task<WikiInfos> GetText(string queryText)
         => await m_httpClient.GetJsonSuccessAsync<WikiInfos>($"{ms_baseURL}wikisearch", "Can not get wiki info", Create("text", queryText));
    }
}
