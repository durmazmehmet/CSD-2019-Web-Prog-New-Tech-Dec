using CSD.Extensions.Net.Http;
using CSD.ParticipansAppRestClientService.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Tuple;

namespace CSD.ParticipantsAppRestClient.Services
{
    public class ParticipantService : IParticipantService
    {
        //01. bağlantıyı sağlamak için tümce
        private const string ms_baseURL = "http://192.168.1.4:50500/api/Participants/";

        //02. bağlantıyı sağlayacağımız sınıf. Startup.cs'de singleton olarak da eklendi
        private readonly HttpClient m_httpClient;

        //03. ctor ile enjekte ettik
        public ParticipantService(HttpClient httpClient) => m_httpClient = httpClient;

        public async Task<List<ParticipantModel>> FindAllAsync()
            => await m_httpClient.GetJsonSuccessAsync<List<ParticipantModel>>($"{ms_baseURL}all", "Can not get data");

        public async Task<ParticipantModel> FindByIdAsync(string id)
            => await m_httpClient.GetJsonSuccessAsync<ParticipantModel>($"{ms_baseURL}info","Can not get data", Create("email", id));

        public async Task<ParticipantModel> SaveParticipant(ParticipantModel participant)
            => await m_httpClient.PostJsonWithResultSuccessAsync($"{ms_baseURL}add", participant, "can not post data");

        public async Task<ParticipantModel> UpdateParticipant(ParticipantModel participant)
            => await m_httpClient.PostJsonWithResultSuccessAsync($"{ms_baseURL}update", participant, "can not post data");

        public async Task<List<ParticipantModel>> FindNotParticipateds()
            => await m_httpClient.GetJsonSuccessAsync<List<ParticipantModel>>($"{ms_baseURL}isParticipated", "Can not get data", Create("participate", "False"));

        public async Task<List<ParticipantModel>> FindParticipateds()
            => await m_httpClient.GetJsonSuccessAsync<List<ParticipantModel>>($"{ms_baseURL}isParticipated", "Can not get data", Create("participate", "True"));

        public async Task<ParticipantModel> DeleteParticipant(ParticipantModel participant)
            => await m_httpClient.GetJsonSuccessAsync<ParticipantModel>($"{ms_baseURL}deleteParticipant", "Can not get data", Create("email", participant.Id));        
    }
}