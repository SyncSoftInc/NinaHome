using Nina.DTO;
using SyncSoft.App.Components;
using SyncSoft.App.Http;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.Api.ContactMessage
{
    public class ClassScheduleMessageApi : IClassScheduleMessageApi
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IHttpClient> _lazyHttpClient = ObjectContainer.LazyResolve<IHttpClient>();
        private IHttpClient HttpClient => _lazyHttpClient.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CRUD  -

        public async Task<HttpResult<string>> CreateMessageAsync(object cmd)
        {
            var hr = await HttpClient.PostAsync(null, new Uri("http://localhost:5002/api/class/message"), cmd).ConfigureAwait(false);
            return new HttpResult<string>(hr);
        }

        public async Task<HttpResult<string>> DeleteMessageAsync(Guid id)
        {
            var hr = await HttpClient.DeleteAsync(null, new Uri($"http://localhost:5002/api/class/message/{id}")).ConfigureAwait(false);
            return new HttpResult<string>(hr);
        }

        public async Task<HttpResult<ClassScheduleMessageDTO>> GetMessageAsync(Guid id)
        {
            var hr = await HttpClient.GetAsync(null, new Uri($"http://localhost:5002/api/class/message/{id}")).ConfigureAwait(false);
            return new HttpResult<ClassScheduleMessageDTO>(hr);
        }

        public async Task<HttpResult<PagedList<ClassScheduleMessageDTO>>> GetMessagesAsync(object query)
        {
            var hr = await HttpClient.GetAsync(null, new Uri("http://localhost:5002/api/class/messages"), query).ConfigureAwait(false);
            return new HttpResult<PagedList<ClassScheduleMessageDTO>>(hr);
        }

        #endregion
    }
}
