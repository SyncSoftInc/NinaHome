using Nina.DTO;
using SyncSoft.App.Components;
using SyncSoft.App.Http;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.Api.TestimonialMessage
{
    public class TestimonialMessageApi : ITestimonialMessageApi
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
            var hr = await HttpClient.PostAsync(null, new Uri("http://localhost:5002/api/testimonial/message"), cmd).ConfigureAwait(false);
            return new HttpResult<string>(hr);
        }

        public async Task<HttpResult<string>> ApproveMessageAsync(object cmd)
        {
            var hr = await HttpClient.PatchAsync(null, new Uri($"http://localhost:5002/api/testimonial/message"), cmd).ConfigureAwait(false);
            return new HttpResult<string>(hr);
        }

        public async Task<HttpResult<string>> DeleteMessageAsync(Guid id)
        {
            var hr = await HttpClient.DeleteAsync(null, new Uri($"http://localhost:5002/api/testimonial/message/{id}")).ConfigureAwait(false);
            return new HttpResult<string>(hr);
        }

        public async Task<HttpResult<ContactMessageDTO>> GetMessageAsync(Guid id)
        {
            var hr = await HttpClient.GetAsync(null, new Uri($"http://localhost:5002/api/testimonial/message/{id}")).ConfigureAwait(false);
            return new HttpResult<ContactMessageDTO>(hr);
        }

        public async Task<HttpResult<PagedList<ContactMessageDTO>>> GetMessagesAsync(string name = null, int pageSize = 0, int pageIndex = 0)
        {
            var hr = await HttpClient.GetAsync(null, new Uri($"http://localhost:5002/api/testimonial/messages?name={name}&pageSize={pageSize}&pageIndex={pageIndex}")).ConfigureAwait(false);
            return new HttpResult<PagedList<ContactMessageDTO>>(hr);
        }

        #endregion
    }
}
