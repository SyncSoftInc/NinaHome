using MongoDB.Driver;
using Nina.DTO;
using Nina.Queries;
using SyncSoft.App.Components;
using SyncSoft.ECP.DTOs;
using System;
using System.Threading.Tasks;

namespace Nina.DataAccess.TestimonialMessage
{
    public class TestimonialMessageDAL : ITestimonialMessageDAL
    {
        // *******************************************************************************************************************************
        #region -  Property(ies)  -

        private IHomeDB DB => HomeDBProvider.Get();

        #endregion
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<HomeDBProvider> _lazyHomeDBProvider = ObjectContainer.LazyResolve<HomeDBProvider>();
        private HomeDBProvider HomeDBProvider => _lazyHomeDBProvider.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CRUD  -

        public Task<string> InsertMessageAsync(TestimonialMessageDTO dto)
            => DB.TestimonialMessages.TryInsertOneAsync(dto);

        public Task<string> ApproveMessageAsync(Guid id, bool approved)
            => DB.TestimonialMessages.TryFindOneAndUpdateAsync(x => x.ID == id, Builders<TestimonialMessageDTO>.Update.Set(x => x.Approved, approved));

        public Task<string> DeleteMessageAsync(Guid id)
            => DB.TestimonialMessages.TryDeleteOneAsync(x => x.ID == id);

        public Task<TestimonialMessageDTO> GetMessageAsync(Guid id)
            => DB.TestimonialMessages.TryFindAndGetOneAsync(x => x.ID == id);

        public async Task<PagedList<TestimonialMessageDTO>> GetMessagesAsync(GetTestimonialMessageQuery query)
        {
            // 搜索
            var filter = Builders<TestimonialMessageDTO>.Filter.Empty;
            if (query.Name.IsPresent())
            {
                var nameFilter = Builders<TestimonialMessageDTO>.Filter.Regex(x => x.Name, query.Name);
                filter = Builders<TestimonialMessageDTO>.Filter.And(filter, nameFilter);
            }
            if (query.Approved.IsNotNull())
            {
                var approvedFilter = Builders<TestimonialMessageDTO>.Filter.Eq(x => x.Approved, query.Approved.Value);
                filter = Builders<TestimonialMessageDTO>.Filter.And(filter, approvedFilter);
            }

            // 输出数据
            var fluent = DB.TestimonialMessages.Find(filter);
            var total = await fluent.CountDocumentsAsync().ConfigureAwait(false);

            fluent = fluent.SortByDescending(x => x.CreatedOnUtc);
            if (query.PageSize > 0 && query.PageIndex > 0)
            {
                fluent = fluent
                    .Skip((query.PageIndex - 1) * query.PageSize)
                    .Limit(query.PageSize);
            }

            var list = await fluent.TryToListAsync().ConfigureAwait(false);

            return new PagedList<TestimonialMessageDTO>(total, query.PageSize, list);

        }

        #endregion
    }
}
